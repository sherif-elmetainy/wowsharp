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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WOWSharp.BattleNet.Authenticator
{
    public class AuthenticatorDefaults
    {
        public static IReadOnlyCollection<string> Regions { get; } = new ReadOnlyCollection<string>(
                new[] { "US", "EU", "TW", "KR", "CN" }
            );

        public static string SerialValidationExpression { get; } = InitSerialValidationExpression();
        public static string RestoreCodeValidationExpression { get; } = "^[0-9a-zA-Z]{10}$";

        private static string InitSerialValidationExpression()
        {
            return "^(?:" + string.Join("|", Regions.Select(RegionRegexPart)) + ")(?:-[0-9]{4}){3}$";
        }

        private static string RegionRegexPart(string r)
        {
            return "(?:" + r[0] + "|" + char.ToLowerInvariant(r[0]) + r[1] + "|" + char.ToLowerInvariant(r[1]) + ")";
        }

        public const int SerialLength = 17;
        public const int SecretKeyLength = 20;
        public const string DeviceName = "WOWSharp client";
    }
}
