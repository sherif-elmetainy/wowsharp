#region LICENSE
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

using System;
using Microsoft.Framework.Internal;
using Newtonsoft.Json.Linq;
using WOWSharp.Interfaces;

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// Helper method for battle.net authentication
    /// </summary>
    internal static class BattleNetAuthenticationHelper
    {
        /// <summary>
        /// Get user's id from json payload
        /// </summary>
        /// <param name="user">json payload</param>
        /// <returns>User's id</returns>
        internal static string GetId([NotNull] this JObject user)
        {
            return user.TryGetValue("id");
        }

        /// <summary>
        /// Get user's battletag from json payload
        /// </summary>
        /// <param name="user">json payload</param>
        /// <returns>User's battletag</returns>
        internal static string GetBattleTag([NotNull] this JObject user)
        {
            return user.TryGetValue("battletag");
        }

        /// <summary>
        /// Get user's property from json payload
        /// </summary>
        /// <param name="user">json payload</param>
        /// <param name="propertyName">property name to read</param>
        /// <returns>User's property</returns>
        private static string TryGetValue(this JObject user, string propertyName)
        {
            JToken value;
            return user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }

        /// <summary>
        /// Changes the host information of a url to match that of the selected region
        /// </summary>
        /// <param name="uri">URL to change</param>
        /// <param name="region">Region to get host information from. If null uri is not changed.</param>
        /// <returns>Modified URI</returns>
        internal static Uri ChangeUriRegion([NotNull] this Uri uri, Region region)
        {
            if (region != null)
            {
                var path = uri.PathAndQuery;
                var host = path.StartsWith(BattleNetAuthenticationDefaults.UserInformationEndpoint, StringComparison.OrdinalIgnoreCase) ? region.ApiHost : region.OAuthHost;
                var baseUri = new Uri("https://" + host);
                uri = new Uri(baseUri, path);
            }
            return uri;
        }

        /// <summary>
        /// Changes the host information of a url to match that of the selected region
        /// </summary>
        /// <param name="url">URL to change</param>
        /// <param name="region">Region to get host information from. If null uri is not changed.</param>
        /// <returns>Modified URI</returns>
        internal static string ChangeUrlRegion([NotNull] this string url, Region region)
        {
            if (region != null)
            {
                var uri = new Uri(url).ChangeUriRegion(region);
                return uri.ToString();
            }
            return url;
        }
    }
}
