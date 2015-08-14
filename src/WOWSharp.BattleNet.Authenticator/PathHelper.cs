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

#if !DOTNET
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Framework.Internal;

namespace WOWSharp.BattleNet.Authenticator
{
    public class PathHelper
    {
        public static string GetAuthenticatorsSavePath([NotNull] string accountName)
        {
            accountName = GetFileNameFromAccountName(accountName);

            return Path.Combine(GetAuthenticatorsSaveFolder(), accountName + ".dat");
        }

        public static string GetAuthenticatorsSaveFolder()
        {
            // On Windows it goes to %APPDATA%\WOWSharp\Authenticators\
            // On Mac/Linux it goes to ~/.wowsharp/authenticators/

            var root = Environment.GetEnvironmentVariable("APPDATA");
            if (root == null)
            {
                root = Environment.GetEnvironmentVariable("HOME");
                Debug.Assert(root != null, "Either HOME and APPDATA Environment Variables must be set.");
                return Path.Combine(root, ".wowsharp", "authenticators");
            }
            else
            {
                return Path.Combine(root, "WOWSharp", "Authenticators");
            }
        }

        public static IEnumerable<string> GetAccountNames()
        {
            var folder = GetAuthenticatorsSaveFolder();
            return Directory.GetFiles(folder, "*.dat").Select(f => GetAccountNameFromFileName(Path.GetFileNameWithoutExtension(f)));
        }

        private static readonly Regex FindSpecialChars = new Regex("_x(?<d>[0-9a-fA-F]+)_", RegexOptions.CultureInvariant | RegexOptions.Compiled);

        private static string GetAccountNameFromFileName(string fileName)
        {
            return FindSpecialChars.Replace(fileName, m =>
            {
                var c = (char)int.Parse(m.Groups["d"].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                return c.ToString();
            });
        }

        private static string GetFileNameFromAccountName(string accountName)
        {
            int index;
            while ((index = accountName.IndexOfAny(Path.GetInvalidFileNameChars())) >= 0)
            {
                accountName = accountName.Replace(accountName[index].ToString(), "_x" + ((int)accountName[index]).ToString("x") + "_");
            }
            return accountName;
        }
    }
}
#endif