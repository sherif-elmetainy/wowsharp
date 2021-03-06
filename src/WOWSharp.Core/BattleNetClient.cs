﻿#region LICENSE
// Copyright (C) 2015 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

#if LOGGING
using Microsoft.Framework.Logging;
#endif
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using WOWSharp.Interfaces;

#if DNXCORE50
using WOWSharp.Core.Serialization;
#endif

#if DNXCORE50 || DNX451
using Microsoft.Framework.OptionsModel;
#endif

namespace WOWSharp.Core
{
    public class BattleNetClient : IBattleNetClient
    {
        private readonly IBattleNetCache _cache;
        private readonly IRegionSelector _regionSelector;
        private readonly ILocaleSelector _localeSelector;
        private readonly HttpClient _httpClient;
        private readonly BattleNetClientOptions _options;
        private readonly IBattleNetAccessTokenAccessor _accessTokenAccessor;
        private readonly JsonSerializer _jsonSerializer;
        private readonly IBattleNetCachePolicy _cachePolicy;

#if LOGGING
        private readonly ILogger _logger;
#endif



        public BattleNetClient(
#if LOGGING
                ILoggerFactory loggerFactory,
#endif
#if DNXCORE50 || DNX451
                IOptions<BattleNetClientOptions> options,
#else
                BattleNetClientOptions options,
#endif
                HttpClient httpclient = null,
                IRegionSelector regionSelector = null,
                ILocaleSelector localeSelector = null,
                IBattleNetAccessTokenAccessor accessTokenAccessor = null,
                IBattleNetCachePolicy cachePolicy = null,
                IBattleNetCache cache = null
            )
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
#if LOGGING
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger(GetType().FullName);
#endif
            

            _httpClient = httpclient ?? new HttpClient();
            _regionSelector = regionSelector ?? DefaultRegionSelector.DefaultInstance;
            _localeSelector = localeSelector;
#if DNXCORE50 || DNX451
            _options = options.Value;
#else
            _options = options;
#endif


            _cache = cache;
            _cachePolicy = cachePolicy;
            _accessTokenAccessor = accessTokenAccessor;
            _jsonSerializer = new JsonSerializer()
            {
                MissingMemberHandling = _options.ThrowErrorOnMissingMembers ? MissingMemberHandling.Error : MissingMemberHandling.Ignore
            };
        }

        /// <summary>
        /// Writes a verbose log message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("LOGGING")]
        // ReSharper disable once UnusedParameter.Local
        private void LogVerbose(string message)
        {
#if LOGGING
            _logger.LogVerbose(message);
#endif
        }

        /// <summary>
        /// Writes an error message to log
        /// </summary>
        /// <param name="message"></param>
        [Conditional("LOGGING")]
        // ReSharper disable once UnusedParameter.Local
        private void LogError(string message)
        {
#if LOGGING
            _logger.LogError(message);
#endif
        }

        /// <summary>
        /// Writes an warning message to log
        /// </summary>
        /// <param name="message"></param>
        [Conditional("LOGGING")]
        // ReSharper disable once UnusedParameter.Local
        private void LogWarning(string message)
        {
#if LOGGING
            _logger.LogWarning(message);
#endif
        }

        /// <summary>
        /// Fetches an and parse data from battle.net API and tries to use cache if possible
        /// </summary>
        /// <typeparam name="TResult">Type of item to retrieve</typeparam>
        /// <param name="path">Path of item to retrieve</param>
        /// <returns>Fetched and parsed items</returns>
        public async Task<TResult> GetAsync<TResult>(string path) where TResult : ApiResponse
        {
            var region = _regionSelector?.GetDefaultRegion() ?? Region.Default;
            var locale = _localeSelector?.GetLocale(region) ?? region.GetSupportedLocale(null);
            var isUserInformation = typeof(UserInformationApiResponse).IsAssignableFrom(typeof(TResult));
            var isBlob = typeof(BlobWrapper) == typeof(TResult);
            var key = isBlob || isUserInformation ? $"{region.Name.ToLowerInvariant()}/{path.ToLowerInvariant()}" : $"{region.Name.ToLowerInvariant()}/{locale.ToLowerInvariant()}/{path.ToLowerInvariant()}";

            // Attempt to get item from cache
            TResult cacheResult = null;
            if (_cache != null)
            {
                cacheResult = (await _cache.GetAsync(key)) as TResult;
            }
            if (cacheResult != null)
            {
                LogVerbose($"CacheHit: {key}");
                // Check policy for item and whether to return the cached item immediately or check if it was modified
                var options = _cachePolicy.GetBattleNetCacheOptions(cacheResult);
                if (!options.ShouldCheckIfCachedEntriesAreModified)
                {
                    return cacheResult;
                }
            }
            else
            {
                LogVerbose($"CacheMiss: {key}");
            }

            // Perform actual call to bnet API
            DateTimeOffset? lastModified = cacheResult?.LastModified;
            TResult result;
            if (isUserInformation)
            {
                result = await GetUserInformationAsync<TResult>(region, path, lastModified).ConfigureAwait(false);
            }
            else
            {
                result = await GetAsync<TResult>(region, locale, path, lastModified).ConfigureAwait(false);
            }
            // Add item to cache
            await AddToCacheAsync(key, result);
            return result ?? cacheResult;
        }

        /// <summary>
        /// Adds an item to cache
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">object to add</param>
        /// <returns>Async task</returns>
        private async Task AddToCacheAsync(string key, object obj)
        {
            if (obj != null && _cache != null)
            {
                var options = _cachePolicy?.GetBattleNetCacheOptions(obj) ?? BattleNetCacheOptions.Default;
                if (options.CacheDurationSeconds > 0)
                {
                    LogVerbose($"CacheAdd: {key}, {options.CacheDurationSeconds} secs, sliding: {options.UseSlidingExpiration}");
                    await _cache.SetAsync(key, obj, options);
                }
            }
        }

        /// <summary>
        /// Fetches an item from battle.net directly without using cache
        /// </summary>
        /// <typeparam name="TResult">type</typeparam>
        /// <param name="region">region</param>
        /// <param name="locale">locale</param>
        /// <param name="path">path of item to retrieve</param>
        /// <param name="ifModifiedSince">setting of If-Modified-Since HTTP header</param>
        /// <returns>Result or null if the HTTP server returned not modified status</returns>
        /// <exception cref="ApiException">The server returned a failure error code</exception>
        public Task<TResult> GetAsync<TResult>(Region region, string locale, string path, DateTimeOffset? ifModifiedSince = null) where TResult : ApiResponse
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (string.IsNullOrWhiteSpace(locale)) throw new ArgumentNullException(nameof(locale));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

            Uri uri = typeof(BlobWrapper) == typeof(TResult) ? GetBlobUri(region, path) : GetUri(region, locale, path);
            return GetInternalAsync<TResult>(uri, path, ifModifiedSince);
        }

        /// <summary>
        /// Fetches an item that requires user authorization without using cache
        /// </summary>
        /// <typeparam name="TResult">type of item to retrieve</typeparam>
        /// <param name="region">battle.net region</param>
        /// <param name="path">path</param>
        /// <param name="ifModifiedSince">setting of If-Modified-Since HTTP header</param>
        /// <returns>Result or null if the HTTP server returned not modified status</returns>
        /// <exception cref="ApiException">The server returned a failure error code</exception>
        public Task<TResult> GetUserInformationAsync<TResult>(Region region, string path, DateTimeOffset? ifModifiedSince) where TResult : ApiResponse
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            var uri = GetUserInformationUri(region, path);
            return GetInternalAsync<TResult>(uri, path, ifModifiedSince);
        }

        /// <summary>
        /// Gets the Uri for the api call
        /// </summary>
        /// <param name="region">battle.net region</param>
        /// <param name="locale">locale</param>
        /// <param name="path">path</param>
        /// <returns>Uri for the api call</returns>
        private Uri GetUri(Region region, string locale, string path)
        {
            var host = region.ApiHost;
            var uri = new Uri("https://" + host + "/" + path);
            var query = (string.IsNullOrEmpty(uri.Query) ? "?" : "&") + $"locale={Uri.EscapeUriString(locale.Replace('-', '_'))}&apikey={Uri.EscapeUriString(_options.ApiKey)}";
            uri = new Uri(uri + query);
            return uri;
        }

        /// <summary>
        /// Gets the Uri for the blob call
        /// </summary>
        /// <param name="region">battle.net region</param>
        /// <param name="path">path</param>
        /// <returns>Uri for the blob call</returns>
        private Uri GetBlobUri(Region region, string path)
        {
            var host = region.OAuthHost;
            var uri = new Uri("https://" + host + "/" + path);
            return uri;
        }

        /// <summary>
        /// Gets the uri for the user information call
        /// </summary>
        /// <param name="region">battle.net region</param>
        /// <param name="path">path</param>
        /// <returns>Uri for the api call</returns>
        private Uri GetUserInformationUri(Region region, string path)
        {
            if (_accessTokenAccessor == null)
            {
                var error = $"BNetApi: No instance of {typeof(IBattleNetAccessTokenAccessor).Name} service was provided for the this instance of {typeof(BattleNetClient).Name}.";
                LogError(error);

                throw new InvalidOperationException(error);
            }
            var host = region.ApiHost;
            var uri = new Uri("https://" + host + "/" + path);
            var token = _accessTokenAccessor.GetCurrentUserAccessToken();
            if (string.IsNullOrWhiteSpace(token))
            {
                var error = "BNetApi: Unable to obtain access token for user. User is not authenticated or not authorization failed.";
                LogWarning(error);
                throw new ApiException(error);
            }
            var query = (string.IsNullOrEmpty(uri.Query) ? "?" : "&") + $"access_token={token}";
            uri = new Uri(uri + query);
            return uri;
        }

        /// <summary>
        /// Performs actual http call to get information then parses it
        /// </summary>
        /// <typeparam name="TResult">type of item to retrieve</typeparam>
        /// <param name="uri">Uri</param>
        /// <param name="path">Path</param>
        /// <param name="ifModifiedSince">setting of If-Modified-Since HTTP header</param>
        /// <returns>Result or null if the HTTP server returned not modified status</returns>
        /// <exception cref="ApiException">The server returned a failure error code</exception>
        private async Task<TResult> GetInternalAsync<TResult>(Uri uri, string path,  DateTimeOffset? ifModifiedSince) where TResult: ApiResponse
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.IfModifiedSince = ifModifiedSince;
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotModified)
            {
                LogVerbose($"BnetNotModified: {uri}");
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                LogVerbose($"BnetSuccess: {uri}");
                return await DeserializeResponse<TResult>(response, path);
            }
            else
            {
                ApiError error;
                try
                {
                    error = await DeserializeResponse<ApiError>(response, path).ConfigureAwait(false);
                }
                catch(JsonException)
                {
                    error = null;
                }
                LogError($"BnetApiError: {uri}, Status Code {response.StatusCode}, error: {error?.Reason}");
                throw new ApiException(error, response.StatusCode, null);
            }
        }

        /// <summary>
        /// Deserializes a response
        /// </summary>
        /// <typeparam name="TResult">Type of response</typeparam>
        /// <param name="responseMessage">response message</param>
        /// <param name="path">path</param>
        /// <returns>Result</returns>
        private async Task<TResult> DeserializeResponse<TResult>(HttpResponseMessage responseMessage, string path) where TResult : ApiResponse
        {
            var isBlob = typeof(BlobWrapper) == typeof(TResult);
            if (isBlob)
            {
                var apiResonseResult = new BlobWrapper
                {
                    Content = await responseMessage.Content.ReadAsByteArrayAsync().ConfigureAwait(false),
                    ContentType = responseMessage.Content.Headers.ContentType.MediaType,
                    Path = path
                };
                return (TResult)(ApiResponse)apiResonseResult;
            }
            var responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            try
            {
                var textReader = new StreamReader(responseStream);
                // textReader now owns responseStream and will dispose it
                // Make sure that responseStream.Dispose is not called more than once
                // by setting responseStream to null
                responseStream = null;
                try
                {
                    var serializer = _jsonSerializer;
                    using (var jsonReader = new JsonTextReader(textReader))
                    {
                        // jsonReader now owns textReader and will dispose it.
                        // Make sure that responseStream.Dispose is not called more than once 
                        // by setting textReader to null
                        textReader = null;

                        // Deserialization is a CPU bound operation
                        // But since some calls return big data (such as auction dump api)
                        // Serialization can take a long time
                        // therefore make it a separate task so that it doesn't block main thread
                        var deserializeTask =
                            // ReSharper disable once AccessToDisposedClosure
                            // Task is awaited before disposed, so therefore will not be disposed in the closure.
                            new Task<TResult>(() => serializer.Deserialize<TResult>(jsonReader));
                        deserializeTask.Start();
                        var apiResponseResult = await deserializeTask.ConfigureAwait(false);
                        
                        apiResponseResult.LastModified = responseMessage.Content.Headers.LastModified ?? DateTimeOffset.Now;
                        // Post serialization
                        apiResponseResult.Path = path;
                        return apiResponseResult;
                    }
                }
                finally
                {
                    textReader?.Dispose();
                }
            }
            finally
            {
                responseStream?.Dispose();
            }
        }
    }
}
