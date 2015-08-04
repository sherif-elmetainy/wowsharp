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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WOWSharp.BattleNet.Authenticator
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticatorDataRepository _repository;

        public Authenticator([NotNull] IAuthenticatorDataRepository repository)
        {
            _repository = repository;
        }

        private static long GetServerUnixTimeMilliseconds(TimeSpan serverTimeDifference)
        {
#if !DNXCORE50
            var referenceDate = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            return (long)Math.Round((DateTimeOffset.UtcNow + serverTimeDifference - referenceDate).TotalMilliseconds);
#else
            return (DateTimeOffset.UtcNow + serverTimeDifference).ToUnixTimeMilliseconds();
#endif
        }

        public async Task<AuthenticatorCode> GetAuthenticatorCodeAsync([NotNull] string accountName)
        {
            var data = await _repository.GetAuthenticatorByAccountNameAsync(accountName);

            var hmac = new HMACSHA1(data.SecretKey);
            var serverTime = GetServerUnixTimeMilliseconds(data.ServerTimeDifference);
            byte[] intervalArray = BitConverter.GetBytes(serverTime / 30000L);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(intervalArray);
            }
            var mac = hmac.ComputeHash(intervalArray);

            // the last 4 bits of the mac say where the code starts(e.g. if last 4 bit are 1100, we start at byte 12)
            int start = mac[19] & 0x0f;

            // extract those 4 bytes
            var bytes = new byte[4];
            Array.Copy(mac, start, bytes, 0, 4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            uint fullcode = BitConverter.ToUInt32(bytes, 0) & 0x7fffffff;

            // we use the last 8 digits of this code in radix 10
            string code = (fullcode % 100000000).ToString("00000000");
            return new AuthenticatorCode()
            {
                Code = code,
                RemainingMilliseconds = 30000L - serverTime % 30000L
            };
        }

        
    }
}
