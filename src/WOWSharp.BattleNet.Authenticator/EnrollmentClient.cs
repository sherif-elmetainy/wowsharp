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

// A lot of code in this file is based on code from the winauth project
// Thanks for the author for making his code freely available
// Copyright(C) 2013 Colin Mackie.
// https://github.com/winauth/winauth/blob/master/LICENSE

#endregion

using Microsoft.Framework.Internal;
#if LOGGING
using Microsoft.Framework.Logging;
#endif
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WOWSharp.BattleNet.Authenticator
{
    public class EnrollmentClient : IEnrollmentClient
    {
        /// <summary>
        /// The RSA public key used by blizzard enrollment service
        /// </summary>
        private static readonly RSAParameters _enrollmentServiceRsaParameters =
            new RSAParameters()
            {
                Modulus = new byte[]
                {
                    0x95, 0x5e, 0x4b, 0xd9, 0x89, 0xf3, 0x91, 0x7d, 0x2f, 0x15, 0x54, 0x4a, 0x7e, 0x05, 0x04, 0xeb, 0x9d, 0x7b, 0xb6, 0x6b, 0x6f, 0x8a, 0x2f, 0xe4, 0x70, 0xe4, 0x53, 0xc7, 0x79, 0x20, 0x0e, 0x5e,
                    0x3a, 0xd2, 0xe4, 0x3a, 0x02, 0xd0, 0x6c, 0x4a, 0xdb, 0xd8, 0xd3, 0x28, 0xf1, 0xa4, 0x26, 0xb8, 0x36, 0x58, 0xe8, 0x8b, 0xfd, 0x94, 0x9b, 0x2a, 0xf4, 0xea, 0xf3, 0x00, 0x54, 0x67, 0x3a, 0x14,
                    0x19, 0xa2, 0x50, 0xfa, 0x4c, 0xc1, 0x27, 0x8d, 0x12, 0x85, 0x5b, 0x5b, 0x25, 0x81, 0x8d, 0x16, 0x2c, 0x6e, 0x6e, 0xe2, 0xab, 0x4a, 0x35, 0x0d, 0x40, 0x1d, 0x78, 0xf6, 0xdd, 0xb9, 0x97, 0x11,
                    0xe7, 0x26, 0x26, 0xb4, 0x8b, 0xd8, 0xb5, 0xb0, 0xb7, 0xf3, 0xac, 0xf9, 0xea, 0x3c, 0x9e, 0x00, 0x05, 0xfe, 0xe5, 0x9e, 0x19, 0x13, 0x6c, 0xdb, 0x7c, 0x83, 0xf2, 0xab, 0x8b, 0x0a, 0x2a, 0x99
                },
                Exponent = new byte[]
                {
                    0x01, 0x01
                }
            };

        private static readonly Uri _cnHost = new Uri("http://mobile-service.blizzard.com.cn/");
        private static readonly Uri _host = new Uri("http://mobile-service.blizzard.com/");
        private const string _syncUrl = "/enrollment/time.htm";
        private const string _restoreUrl = "/enrollment/initiatePaperRestore.htm";
        private const string _validateRestoreUrl = "/enrollment/validatePaperRestore.htm";
        private const string _enrollUrl = "/enrollment/enroll2.htm";

#if LOGGING

        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public EnrollmentClient(
                [NotNull] ILoggerFactory logger
            )
        {
            _logger = logger.CreateLogger<EnrollmentClient>();
        }
#endif

        public async Task<AuthenticatorData> EnrollAuthenticatorAsync([NotNull] string regionCode)
        {
            Validation.ValidateRegionCode(regionCode);

            LogVerbose($"Initiating enroll request for region code: '{regionCode}'.");
            var result = new AuthenticatorData()
            {
                RegionCode = regionCode
            };
            var enrollRequest = new byte[38];
            var otp = GenerateOneTypePad(20);
            otp.CopyTo(enrollRequest, 0);
            Encoding.UTF8.GetBytes(regionCode, 0, 2, enrollRequest, otp.Length);
            Encoding.UTF8.GetBytes(AuthenticatorDefaults.DeviceName, 0, AuthenticatorDefaults.DeviceName.Length, enrollRequest, otp.Length);

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(_enrollmentServiceRsaParameters);
                var encrypted = rsa.Encrypt(enrollRequest, false);
                using (var httpClient = new HttpClient())
                {
                    using (var postStream = new MemoryStream(encrypted))
                    {
                        var postContent = new StreamContent(postStream);
                        postContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        var response = await httpClient.PostAsync(GetUri(regionCode, _enrollUrl), postContent).ConfigureAwait(false);
                        if (!response.IsSuccessStatusCode)
                        {
                            var error = $"Enroll request failed because server returned error code: {response.StatusCode}";
                            LogError(error);
                            throw new AuthenticatorException(error);
                        }
                        var enrollResult = await response.Content.ReadAsByteArrayAsync();
                        if (enrollResult.Length != 45)
                        {
                            var error = $"Enroll request failed because server returned invalid content length. Expected 45, Actual {enrollResult.Length}";
                            LogError(error);
                            throw new AuthenticatorException(error);
                        }
                        var serverTime = DateFromServerBytes(enrollResult);
                        var ourTime = DateTimeOffset.Now;
                        var difference = serverTime - ourTime;
                        LogInformation($"Enroll successfull got server time difference for region: '{regionCode}' was successful. Server time '{serverTime}', Our time '{ourTime}', and time difference is '{difference}'.");
                        result.ServerTimeDifference = difference;

                        result.Serial = Encoding.UTF8.GetString(enrollResult, 8, 17);
                        for (var i = 0; i < otp.Length; i++)
                        {
                            otp[i] ^= enrollResult[i + 25];
                        }
                        result.SecretKey = otp;
                        result.RestoreCode = GetRestoreCode(result.Serial, result.SecretKey);
                        
                        LogInformation($"Enroll new serial number is : '{result.Serial}' is complete.");
                    }
                }
            }
            return result;
        }

        public string GetRestoreCode([NotNull] string serial, [NotNull] byte[] secretKey)
        {
            Validation.ValidateSerial(serial);
            Validation.ValidateSecretKey(secretKey);
            byte[] serialdata = Encoding.UTF8.GetBytes(serial.Replace("-", string.Empty));

            // combine serial data and secret data
            var combined = ConcatenateByteArrays(serialdata, secretKey);
            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(combined);
                return new string(hash.Skip(hash.Length - 10).Select(GetRestoreCodeChar).ToArray());
            }
        }

        public async Task<TimeSpan> GetServerTimeDifferenceAsync([NotNull] string regionCode)
        {
            Validation.ValidateRegionCode(regionCode);
            using (var httpClient = new HttpClient())
            {
                LogVerbose($"Attempting to get server time difference for region: '{regionCode}'.");
                var response = await httpClient.GetAsync(GetUri(regionCode, _syncUrl)).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    var error = $"Failed to Get server time different because server returned error code: {response.StatusCode}";
                    LogError(error);
                    throw new AuthenticatorException(error);
                }
                var differenceBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                if (differenceBytes.Length != sizeof(long))
                {
                    var error = $"Failed to Get server time different because server returned content with invalid length. Expected {sizeof(long)}, Actual {differenceBytes.Length}.";
                    LogError(error);
                    throw new AuthenticatorException(error);
                }
                var serverTime = DateFromServerBytes(differenceBytes);
                var ourTime = DateTimeOffset.Now;
                var difference = serverTime - ourTime;
                LogInformation($"Get server time difference for region: '{regionCode}' was successful. Server time '{serverTime}', Our time '{ourTime}', and time difference is '{difference}'.");
                return difference;
            }
        }


        public async Task<AuthenticatorData> RestoreAuthenticatorDataAsync([NotNull] string serial, [NotNull] string restoreCode)
        {
            Validation.ValidateSerial(serial);
            Validation.ValidateRestoreCode(restoreCode);
            serial = serial.ToUpperInvariant();
            var result = new AuthenticatorData()
            {
                RegionCode = serial.Substring(0, 2),
                Serial = serial,
                RestoreCode = restoreCode
            };
            var serialBytes = Encoding.UTF8.GetBytes(serial.Replace("-", ""));
            LogVerbose($"Attempting to initiate restore for Serial '{serial}' was successful.");
            var initRestoreResponse = await InitiateRestore(result.RegionCode, serialBytes);
            LogVerbose($"Initiate restore for Serial '{serial}' was successful.");
            result.SecretKey = await VerifyRestoreAndGetSecretKeyAsync(result.RegionCode, restoreCode, serialBytes, initRestoreResponse);
            LogInformation($"Restore verification for Serial '{serial}' was successful and secret key was retrieved.");
            try
            {
                result.ServerTimeDifference = await GetServerTimeDifferenceAsync(result.RegionCode).ConfigureAwait(false);
            }
            catch (AuthenticatorException ex)
            {
                LogWarning($"Failed to Sync time while restoring authenticator data. Assuming zero time difference. Exception: {ex.Message}");
            }
            return result;
        }

        private async Task<byte[]> VerifyRestoreAndGetSecretKeyAsync(string regionCode, string restoreCode, byte[] serialBytes, byte[] challenge)
        {
            using (var httpClient = new HttpClient())
            {
                var restoreCodeBytes = restoreCode.Select(GetRestoreCodeByte).ToArray();

                using (var hmac = new HMACSHA1(restoreCodeBytes))
                {
                    var dataToHash = ConcatenateByteArrays(serialBytes, challenge);
                    var hash = hmac.ComputeHash(dataToHash);

                    // https://en.wikipedia.org/wiki/One-time_pad
                    var otp = GenerateOneTypePad(AuthenticatorDefaults.SecretKeyLength);
                    var unencrypted = ConcatenateByteArrays(hash, otp);
                    using (var rsa = new RSACryptoServiceProvider())
                    {
                        rsa.ImportParameters(_enrollmentServiceRsaParameters);
                        var encrypted = rsa.Encrypt(unencrypted, false);
                        var postData = ConcatenateByteArrays(serialBytes, encrypted);

                        using (var postStream = new MemoryStream(postData))
                        {
                            var postContent = new StreamContent(postStream);
                            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            var response = await httpClient.PostAsync(GetUri(regionCode, _validateRestoreUrl), postContent).ConfigureAwait(false);
                            if (!response.IsSuccessStatusCode)
                            {
                                var error = $"Validate restore request failed because server returned error code: {response.StatusCode}";
                                LogError(error);
                                throw new AuthenticatorException(error);
                            }
                            var secret = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                            if (secret.Length != otp.Length)
                            {
                                var error = $"Validate restore request failed server returned secret with invalid length. Expected {otp.Length}, Actual {secret.Length}.";
                                LogError(error);
                                throw new AuthenticatorException(error);
                            }
                            // decrypt secret (XOR) 
                            for (int i = otp.Length - 1; i >= 0; i--)
                            {
                                secret[i] ^= otp[i];
                            }
                            return secret;
                        }
                    }
                }
            }
        }

        private async Task<byte[]> InitiateRestore(string regionCode, byte[] serialBytes)
        {
            using (var httpClient = new HttpClient())
            {
                using (var ms = new MemoryStream(serialBytes))
                {
                    var postContent = new StreamContent(ms);
                    postContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    var response = await httpClient.PostAsync(GetUri(regionCode, _restoreUrl), postContent).ConfigureAwait(false);
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = $"Initiate request failed because server returned error code: {response.StatusCode}";
                        LogError(error);
                        throw new AuthenticatorException(error);
                    }
                    var challenge = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    if (challenge.Length != 32)
                    {
                        var error = $"Initiate request failed because server response size was {challenge.Length} while expected size is 32.";
                        LogError(error);
                        throw new AuthenticatorException(error);
                    }
                    return challenge;
                }
            }
        }

        [Conditional("LOGGING")]
        private void LogError(string message)
        {
#if LOGGING
            _logger.LogError(message);
#endif
        }

        [Conditional("LOGGING")]
        private void LogWarning(string message)
        {
#if LOGGING
            _logger.LogWarning(message);
#endif
        }

        [Conditional("LOGGING")]
        private void LogInformation(string message)
        {
#if LOGGING
            _logger.LogInformation(message);
#endif
        }

        [Conditional("LOGGING")]
        private void LogVerbose(string message)
        {
#if LOGGING
            _logger.LogVerbose(message);
#endif
        }

        private static Uri GetUri(string regionCode, string relativeUri)
        {
            var host = regionCode == "CN" ? _cnHost : _host;
            return new Uri(host, relativeUri);
        }

        private static byte[] ConcatenateByteArrays(byte[] b1, byte[] b2)
        {
            var result = new byte[b1.Length + b2.Length];
            b1.CopyTo(result, 0);
            b2.CopyTo(result, b1.Length);
            return result;
        }

        /// <summary>
        /// Convert a char to a byte but with appropriate mapping to exclude I,L,O and S. E.g. A=10 but J=18 not 19 (as I is missing)
        /// </summary>
        /// <param name="c">char to convert.</param>
        /// <returns>byte value of restore code char</returns>
        private static byte GetRestoreCodeByte(char c)
        {
            c = char.ToUpperInvariant(c);
            if (c >= '0' && c <= '9')
            {
                return (byte)(c - '0');
            }
            else if (c < 'A' || c > 'Z')
            {
                throw new ArgumentException($"Invalid character {c} in restoreCode.", nameof(c));
            }
            else
            {
                var value = (byte)(c + 10 - 'A');
                if (c >= 'S')
                {
                    value -= 4;
                }
                else if (c >= 'O')
                {
                    value -= 3;
                }
                else if (c >= 'L')
                {
                    value -= 2;
                }
                else if (c >= 'I')
                {
                    value--;
                }
                return value;
            }
        }

        /// <summary>
        /// Convert a byte to a char but with appropriate mapping to exclude I,L,O and S.
        /// </summary>
        /// <param name="b">byte to convert.</param>
        /// <returns>char value of restore code value</returns>
        private static char GetRestoreCodeChar(byte b)
        {
            int index = b & 0x1f;
            if (index <= 9)
            {
                return (char)(index + '0');
            }
            else
            {
                index = (index + 'A') - 10;
                if (index >= 'I')
                {
                    index++;
                }
                if (index >= 'L')
                {
                    index++;
                }
                if (index >= 'O')
                {
                    index++;
                }
                if (index >= 'S')
                {
                    index++;
                }
                return (char)index;
            }
        }


        /// <summary>
        /// Generate a one time pad (an encryption key used only once) https://en.wikipedia.org/wiki/One-time_pad
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static byte[] GenerateOneTypePad(int length)
        {
            var pad = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(pad);
            }
            return pad;
        }

        private static DateTimeOffset DateFromServerBytes(byte[] dateBytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(dateBytes, 0, 8);
            }
#if !DNXCORE50
            var referenceDate = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var unixTimeMilliseconds = BitConverter.ToInt64(dateBytes, 0);
            return referenceDate.AddMilliseconds(unixTimeMilliseconds);
#else
            return DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(dateBytes, 0));
#endif
        }
    }
}
