using System;
using System.Collections.Generic;
using System.Globalization;
using static WOWSharp.Interfaces.Region;

namespace WOWSharp.Interfaces
{
    /// <summary>
    /// Selects the default region (selects region based on current culture)
    /// </summary>
    public class DefaultRegionSelector : IRegionSelector
    {
        /// <summary>
        /// Default singleton instance for <see cref="DefaultRegionSelector"/>
        /// </summary>
        public static DefaultRegionSelector DefaultInstance { get; } = new DefaultRegionSelector();

        /// <summary>
        ///   A dictionary to lookup region by current thread's culture
        /// </summary>
        private static readonly Dictionary<string, Region> _defaultRegions =
            new Dictionary<string, Region>(StringComparer.OrdinalIgnoreCase)
                {
                    {"af-ZA", EU}, // Afrikaans (South Africa)
                    {"am-ET", EU}, // Amharic (Ethiopia)
                    {"ar-AE", EU}, // Arabic (U.A.E.)
                    {"ar-BH", EU}, // Arabic (Bahrain)
                    {"ar-DZ", EU}, // Arabic (Algeria)
                    {"ar-EG", EU}, // Arabic (Egypt)
                    {"ar-IQ", EU}, // Arabic (Iraq)
                    {"ar-JO", EU}, // Arabic (Jordan)
                    {"ar-KW", EU}, // Arabic (Kuwait)
                    {"ar-LB", EU}, // Arabic (Lebanon)
                    {"ar-LY", EU}, // Arabic (Libya)
                    {"ar-MA", EU}, // Arabic (Morocco)
                    {"ar-OM", EU}, // Arabic (Oman)
                    {"ar-QA", EU}, // Arabic (Qatar)
                    {"ar-SA", EU}, // Arabic (Saudi Arabia)
                    {"ar-SY", EU}, // Arabic (Syria)
                    {"ar-TN", EU}, // Arabic (Tunisia)
                    {"ar-YE", EU}, // Arabic (Yemen)
                    {"arn-CL", US}, // Mapudungun (Chile)
                    {"as-IN", US}, // Assamese (India)
                    {"az-Cyrl-AZ", EU}, // Azeri (Cyrillic, Azerbaijan)
                    {"az-Latn-AZ", EU}, // Azeri (Latin, Azerbaijan)
                    {"ba-RU", EU}, // Bashkir (Russia)
                    {"be-BY", EU}, // Belarusian (Belarus)
                    {"bg-BG", EU}, // Bulgarian (Bulgaria)
                    {"bn-BD", US}, // Bengali (Bangladesh)
                    {"bn-IN", US}, // Bengali (India)
                    {"bo-CN", CN}, // Tibetan (PRC)
                    {"br-FR", EU}, // Breton (France)
                    {"bs-Cyrl-BA", EU}, // Bosnian (Cyrillic, Bosnia and Herzegovina)
                    {"bs-Latn-BA", EU}, // Bosnian (Latin, Bosnia and Herzegovina)
                    {"ca-ES", EU}, // Catalan (Catalan)
                    {"co-FR", EU}, // Corsican (France)
                    {"cs-CZ", EU}, // Czech (Czech Republic)
                    {"cy-GB", EU}, // Welsh (United Kingdom)
                    {"da-DK", EU}, // Danish (Denmark)
                    {"de-AT", EU}, // German (Austria)
                    {"de-CH", EU}, // German (Switzerland)
                    {"de-DE", EU}, // German (Germany)
                    {"de-LI", EU}, // German (Liechtenstein)
                    {"de-LU", EU}, // German (Luxembourg)
                    {"dsb-DE", EU}, // Lower Sorbian (Germany)
                    {"dv-MV", EU}, // Divehi (Maldives)
                    {"el-GR", EU}, // Greek (Greece)
                    {"en-029", US}, // English (Caribbean)
                    {"en-AU", US}, // English (Australia)
                    {"en-BZ", US}, // English (Belize)
                    {"en-CA", US}, // English (Canada)
                    {"en-GB", EU}, // English (United Kingdom)
                    {"en-IE", EU}, // English (Ireland)
                    {"en-IN", EU}, // English (India)
                    {"en-JM", US}, // English (Jamaica)
                    {"en-MY", US}, // English (Malaysia)
                    {"en-NZ", US}, // English (New Zealand)
                    {"en-PH", US}, // English (Republic of the Philippines)
                    {"en-SG", US}, // English (Singapore)
                    {"en-TT", US}, // English (Trinidad and Tobago)
                    {"en-US", US}, // English (United States)
                    {"en-ZA", EU}, // English (South Africa)
                    {"en-ZW", EU}, // English (Zimbabwe)
                    {"es-AR", US}, // Spanish (Argentina)
                    {"es-BO", US}, // Spanish (Bolivia)
                    {"es-CL", US}, // Spanish (Chile)
                    {"es-CO", US}, // Spanish (Colombia)
                    {"es-CR", US}, // Spanish (Costa Rica)
                    {"es-DO", US}, // Spanish (Dominican Republic)
                    {"es-EC", US}, // Spanish (Ecuador)
                    {"es-ES", EU}, // Spanish (Spain)
                    {"es-GT", US}, // Spanish (Guatemala)
                    {"es-HN", US}, // Spanish (Honduras)
                    {"es-MX", US}, // Spanish (Mexico)
                    {"es-NI", US}, // Spanish (Nicaragua)
                    {"es-PA", US}, // Spanish (Panama)
                    {"es-PE", US}, // Spanish (Peru)
                    {"es-PR", US}, // Spanish (Puerto Rico)
                    {"es-PY", US}, // Spanish (Paraguay)
                    {"es-SV", US}, // Spanish (El Salvador)
                    {"es-US", US}, // Spanish (United States)
                    {"es-UY", US}, // Spanish (Uruguay)
                    {"es-VE", US}, // Spanish (Venezuela)
                    {"et-EE", EU}, // Estonian (Estonia)
                    {"eu-ES", EU}, // Basque (Basque)
                    {"fa-IR", EU}, // Persian (Iran)
                    {"fi-FI", EU}, // Finnish (Finland)
                    {"fil-PH", US}, // Filipino (Philippines)
                    {"fo-FO", EU}, // Faroese (Faroe Islands)
                    {"fr-BE", EU}, // French (Belgium)
                    {"fr-CA", EU}, // French (Canada)
                    {"fr-CH", EU}, // French (Switzerland)
                    {"fr-FR", EU}, // French (France)
                    {"fr-LU", EU}, // French (Luxembourg)
                    {"fr-MC", EU}, // French (Principality of Monaco)
                    {"fy-NL", EU}, // Frisian (Netherlands)
                    {"ga-IE", EU}, // Irish (Ireland)
                    {"gd-GB", EU}, // Scottish Gaelic (United Kingdom)
                    {"gl-ES", EU}, // Galician (Galician)
                    {"gsw-FR", EU}, // Alsatian (France)
                    {"gu-IN", US}, // Gujarati (India)
                    {"ha-Latn-NG", EU}, // Hausa (Latin, Nigeria)
                    {"he-IL", EU}, // Hebrew (Israel)
                    {"hi-IN", US}, // Hindi (India)
                    {"hr-BA", EU}, // Croatian (Latin, Bosnia and Herzegovina)
                    {"hr-HR", EU}, // Croatian (Croatia)
                    {"hsb-DE", EU}, // Upper Sorbian (Germany)
                    {"hu-HU", EU}, // Hungarian (Hungary)
                    {"hy-AM", EU}, // Armenian (Armenia)
                    {"id-ID", US}, // Indonesian (Indonesia)
                    {"ig-NG", EU}, // Igbo (Nigeria)
                    {"ii-CN", CN}, // Yi (PRC)
                    {"is-IS", EU}, // Icelandic (Iceland)
                    {"it-CH", EU}, // Italian (Switzerland)
                    {"it-IT", EU}, // Italian (Italy)
                    {"iu-Cans-CA", US}, // Inuktitut (Syllabics, Canada)
                    {"iu-Latn-CA", US}, // Inuktitut (Latin, Canada)
                    {"ja-JP", US}, // Japanese (Japan)
                    {"ka-GE", EU}, // Georgian (Georgia)
                    {"kk-KZ", EU}, // Kazakh (Kazakhstan)
                    {"kl-GL", US}, // Greenlandic (Greenland)
                    {"km-KH", US}, // Khmer (Cambodia)
                    {"kn-IN", US}, // Kannada (India)
                    {"kok-IN", US}, // Konkani (India)
                    {"ko-KR", KR}, // Korean (Korea)
                    {"ky-KG", EU}, // Kyrgyz (Kyrgyzstan)
                    {"lb-LU", EU}, // Luxembourgish (Luxembourg)
                    {"lo-LA", US}, // Lao (Lao P.D.R.)
                    {"lt-LT", EU}, // Lithuanian (Lithuania)
                    {"lv-LV", EU}, // Latvian (Latvia)
                    {"mi-NZ", US}, // Maori (New Zealand)
                    {"mk-MK", EU}, // Macedonian (Former Yugoslav Republic of Macedonia)
                    {"ml-IN", US}, // Malayalam (India)
                    {"mn-MN", CN}, // Mongolian (Cyrillic, Mongolia)
                    {"mn-Mong-CN", CN}, // Mongolian (Traditional Mongolian, PRC)
                    {"moh-CA", US}, // Mohawk (Mohawk)
                    {"mr-IN", US}, // Marathi (India)
                    {"ms-BN", US}, // Malay (Brunei Darussalam)
                    {"ms-MY", US}, // Malay (Malaysia)
                    {"mt-MT", EU}, // Maltese (Malta)
                    {"nb-NO", EU}, // Norwegian, Bokmål (Norway)
                    {"ne-NP", US}, // Nepali (Nepal)
                    {"nl-BE", EU}, // Dutch (Belgium)
                    {"nl-NL", EU}, // Dutch (Netherlands)
                    {"nn-NO", EU}, // Norwegian, Nynorsk (Norway)
                    {"nso-ZA", EU}, // Sesotho sa Leboa (South Africa)
                    {"oc-FR", EU}, // Occitan (France)
                    {"or-IN", US}, // Oriya (India)
                    {"pa-IN", US}, // Punjabi (India)
                    {"pl-PL", EU}, // Polish (Poland)
                    {"prs-AF", EU}, // Dari (Afghanistan)
                    {"ps-AF", EU}, // Pashto (Afghanistan)
                    {"pt-BR", EU}, // Portuguese (Brazil)
                    {"pt-PT", EU}, // Portuguese (Portugal)
                    {"qut-GT", US}, // K'iche (Guatemala)
                    {"quz-BO", US}, // Quechua (Bolivia)
                    {"quz-EC", US}, // Quechua (Ecuador)
                    {"quz-PE", US}, // Quechua (Peru)
                    {"rm-CH", EU}, // Romansh (Switzerland)
                    {"ro-RO", EU}, // Romanian (Romania)
                    {"ru-RU", EU}, // Russian (Russia)
                    {"rw-RW", EU}, // Kinyarwanda (Rwanda)
                    {"sah-RU", EU}, // Yakut (Russia)
                    {"sa-IN", US}, // Sanskrit (India)
                    {"se-FI", EU}, // Sami, Northern (Finland)
                    {"se-NO", EU}, // Sami, Northern (Norway)
                    {"se-SE", EU}, // Sami, Northern (Sweden)
                    {"si-LK", US}, // Sinhala (Sri Lanka)
                    {"sk-SK", EU}, // Slovak (Slovakia)
                    {"sl-SI", EU}, // Slovenian (Slovenia)
                    {"sma-NO", EU}, // Sami, Southern (Norway)
                    {"sma-SE", EU}, // Sami, Southern (Sweden)
                    {"smj-NO", EU}, // Sami, Lule (Norway)
                    {"smj-SE", EU}, // Sami, Lule (Sweden)
                    {"smn-FI", EU}, // Sami, Inari (Finland)
                    {"sms-FI", EU}, // Sami, Skolt (Finland)
                    {"sq-AL", EU}, // Albanian (Albania)
                    {"sr-Cyrl-BA", EU}, // Serbian (Cyrillic, Bosnia and Herzegovina)
                    {"sr-Cyrl-CS", EU}, // Serbian (Cyrillic, Serbia and Montenegro (Former))
                    {"sr-Cyrl-ME", EU}, // Serbian (Cyrillic, Montenegro)
                    {"sr-Cyrl-RS", EU}, // Serbian (Cyrillic, Serbia)
                    {"sr-Latn-BA", EU}, // Serbian (Latin, Bosnia and Herzegovina)
                    {"sr-Latn-CS", EU}, // Serbian (Latin, Serbia and Montenegro (Former))
                    {"sr-Latn-ME", EU}, // Serbian (Latin, Montenegro)
                    {"sr-Latn-RS", EU}, // Serbian (Latin, Serbia)
                    {"sv-FI", EU}, // Swedish (Finland)
                    {"sv-SE", EU}, // Swedish (Sweden)
                    {"sw-KE", EU}, // Kiswahili (Kenya)
                    {"syr-SY", EU}, // Syriac (Syria)
                    {"ta-IN", US}, // Tamil (India)
                    {"te-IN", US}, // Telugu (India)
                    {"tg-Cyrl-TJ", EU}, // Tajik (Cyrillic, Tajikistan)
                    {"th-TH", US}, // Thai (Thailand)
                    {"tk-TM", EU}, // Turkmen (Turkmenistan)
                    {"tn-ZA", EU}, // Setswana (South Africa)
                    {"tr-TR", EU}, // Turkish (Turkey)
                    {"tt-RU", EU}, // Tatar (Russia)
                    {"tzm-Latn-DZ", EU}, // Tamazight (Latin, Algeria)
                    {"ug-CN", CN}, // Uyghur (PRC)
                    {"uk-UA", EU}, // Ukrainian (Ukraine)
                    {"ur-PK", EU}, // Urdu (Islamic Republic of Pakistan)
                    {"uz-Cyrl-UZ", EU}, // Uzbek (Cyrillic, Uzbekistan)
                    {"uz-Latn-UZ", EU}, // Uzbek (Latin, Uzbekistan)
                    {"vi-VN", US}, // Vietnamese (Vietnam)
                    {"wo-SN", EU}, // Wolof (Senegal)
                    {"xh-ZA", EU}, // isiXhosa (South Africa)
                    {"yo-NG", EU}, // Yoruba (Nigeria)
                    {"zh-CN", CN}, // Chinese (People's Republic of China)
                    {"zh-HK", CN}, // Chinese (Hong Kong S.A.R.)
                    {"zh-MO", CN}, // Chinese (Macao S.A.R.)
                    {"zh-SG", CN}, // Chinese (Singapore)
                    {"zh-TW", TW}, // Chinese (Taiwan)
                    {"zu-ZA", EU}, // isiZulu (South Africa)
                };

        /// <summary>
        ///   A dictionary to lookup regions by name
        /// </summary>
        private static readonly Dictionary<string, Region> _regionsDict =
            new Dictionary<string, Region>(StringComparer.OrdinalIgnoreCase)
                {
                    {"EU", EU},
                    {"US", US},
                    {"TW", TW},
                    {"CN", CN},
                    {"KR", KR},
                };

        /// <summary>
        /// Gets the default region based on current culture
        /// </summary>
        /// <returns>Default WOW API Region</returns>
        public virtual Region GetDefaultRegion()
        {
            string cultureName = CultureInfo.CurrentCulture.Name;
            return _defaultRegions[cultureName];
        }

        /// <summary>
        /// Get region by region name
        /// </summary>
        /// <param name="regionName">region name</param>
        /// <returns>Region by region name</returns>
        public virtual Region GetRegion(string regionName)
        {
            if (string.IsNullOrEmpty(regionName))
                return GetDefaultRegion();
            return _regionsDict[regionName];
        }
    }
}
