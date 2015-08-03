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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Interfaces
{
    /// <summary>
    ///   Represents a Region for which battle.net community Api is available
    /// </summary>
    /// <remarks>
    ///   This class is immutable
    /// </remarks>
    public sealed class Region
    {
        /// <summary>
        ///   Gets the info about Americas' regional website
        /// </summary>
        public static Region US { get; } = new Region("US", "us.api.battle.net", "us.battle.net",
            new ReadOnlyCollection<string>(new[]
                {
                    "en-US", "es-MX", "pt-BR"
                }));


        /// <summary>
        ///   Gets the info about Europe's regional website
        /// </summary>
        public static Region EU { get; } = new Region("EU", "eu.api.battle.net", "eu.battle.net",
            new ReadOnlyCollection<string>(new[]
                {
                    "en-GB", "es-ES", "fr-FR",
                    "ru-RU", "de-DE", "pt-PT",
                    "it-IT", "pl-PL"
                }));

        /// <summary>
        ///   Gets the info about Korean regional website
        /// </summary>
        public static Region KR { get; } = new Region("KR", "kr.api.battle.net", "kr.battle.net",
            new ReadOnlyCollection<string>(new[]
                {
                    "ko-KR"
                }));

        /// <summary>
        ///   Gets the info about Taiwanese regional website
        /// </summary>
        public static Region TW { get; } = new Region("TW", "tw.api.battle.net", "tw.battle.net",
            new ReadOnlyCollection<string>(new[] 
                {
                    "zh-TW"
                }));

        /// <summary>
        ///   Gets the info about Chinese regional website
        /// </summary>
        public static Region CN { get; } = new Region("CN", "api.battlenet.com.cn", "www.battlenet.com.cn",
            new ReadOnlyCollection<string>(new[] 
                {
                    "zh-CN"
                }));

        /// <summary>
        ///   Gets a collection of all regions
        /// </summary>
        public static ReadOnlyCollection<Region> AllRegions { get; } = new ReadOnlyCollection<Region>(
            new[]
                {
                    US, EU, KR, TW, CN
                });

        /// <summary>
        ///   Host name of the community website
        /// </summary>
        public string ApiHost { get; }

        /// <summary>
        ///   Host name of the OAUTH community website
        /// </summary>
        public string OAuthHost { get; }

        /// <summary>
        ///   Region's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///   Supported languages
        /// </summary>
        public ReadOnlyCollection<string> SupportedLocales { get; }

        /// <summary>
        ///   Constructor. Initializes a new instance of Region object
        /// </summary>
        /// <param name="name"> Region name </param>
        /// <param name="host"> Host name of the battle.net community website </param>
        /// <param name="oauthHost"> Host name of the OAUTH authorication battle.net community website </param>
        /// <param name="supportedLocales"> Languages supported by the community website </param>
        private Region(string name, string host, string oauthhost, ReadOnlyCollection<string> supportedLocales)
        {
            Name = name;
            ApiHost = host;
            OAuthHost = oauthhost;
            SupportedLocales = supportedLocales;
        }

        /// <summary>
        ///   Gets the default language for the region. Language of the current thread's culture is used if available, otherwise the default language for the regional site is used.
        /// </summary>
        public string DefaultLocale
        {
            get
            {
                return GetSupportedLocale(null);
            }
        }

        /// <summary>
        ///   Get the language supported by the regional website based on culture
        /// </summary>
        /// <param name="cultureName"> The culture to lookup </param>
        /// <returns> Language of the culture specified is returned if available and supported by the website, otherwise the default language for the regional site is used. </returns>
        public string GetSupportedLocale(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName))
                cultureName = CultureInfo.CurrentCulture.Name;
            // try to find the exact culture
            string foundCulture =
                SupportedLocales.FirstOrDefault(sc => string.Equals(cultureName, sc, StringComparison.OrdinalIgnoreCase));
            if (foundCulture == null)
            {
                // if not available, try to find a culture with the same language
                foundCulture =
                    SupportedLocales.FirstOrDefault(
                        sc =>
                        string.Equals(cultureName.Substring(0, 2), sc.Substring(0, 2),
                                      StringComparison.OrdinalIgnoreCase));
                if (foundCulture == null)
                    return SupportedLocales[0]; // if not available get the site's default language
            }
            return foundCulture;
        }

        /// <summary>
        /// Gets the default region based on current culture
        /// </summary>
        public static Region Default => DefaultRegionSelector.DefaultInstance.GetDefaultRegion();
    }
}
