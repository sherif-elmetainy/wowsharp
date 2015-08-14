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
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Framework.Internal;

namespace WOWSharp.BattleNet.Authenticator
{
    internal static class Validation
    {
        private static readonly Regex SerialValidator = new Regex(AuthenticatorDefaults.SerialValidationExpression, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        private static readonly Regex RestoreCodeValidator = new Regex(AuthenticatorDefaults.RestoreCodeValidationExpression, RegexOptions.CultureInvariant);

        public static void ValidateRegionCode([NotNull] string regionCode)
        {
            if (!AuthenticatorDefaults.Regions.Contains(regionCode, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(regionCode), regionCode, $"'{regionCode}' is an invalid region code.");
        }

        public static void ValidateSerial([NotNull] string serial)
        {
            if (!SerialValidator.IsMatch(serial))
            {
                throw new ArgumentException($"Invalid serial number: '{serial}'", nameof(serial));
            }
        }

        public static void ValidateRestoreCode([NotNull] string restoreCode)
        {
            if (!RestoreCodeValidator.IsMatch(restoreCode))
            {
                throw new ArgumentException("Invalid restore code.", nameof(restoreCode));
            }
        }

        public static void ValidateSecretKey([NotNull] byte[] secretKey)
        {
            if (secretKey.Length != AuthenticatorDefaults.SecretKeyLength)
            {
                throw new ArgumentException("Invalid secret key.", nameof(secretKey));
            }
        }
    }
}


