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


using Newtonsoft.Json;
using System;
using System.Globalization;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Gets information about character's boss kills
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterBossKills
    {
        /// <summary>
        ///   Gets or sets the name of the boss
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the creature id
        ///   Boss ID is equal to zero in council type fights (For example Four Horsemen, Assembly of Iron, Val'kyr Twins, etc)
        ///   Or fights where there is no boss (Gunship Battle)
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined
        ///   It can also mean that the character killed the boss in heroic mode only and never in normal mode.).
        /// </summary>
        [JsonProperty(PropertyName="normalKills")]
        public int NormalKills
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the number of kills in normal mode (if the value is negative it means that the character has killed the boss at least once, but number of kills cannot be determined)
        /// </summary>
        [JsonProperty(PropertyName="heroicKills")]
        public int? HeroicKills
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets the number of kills in flexible raid mode
        /// </summary>
        [JsonProperty(PropertyName="flexKills")]
        public int? FlexKills
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets the number of Kills in looking for raid mode.
        /// </summary>
        [JsonProperty(PropertyName="lfrKills")]
        public int? LfrKills
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date and time of the heroic first kill in Utc
        /// A value of null means either the boss doesn't have heroic mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        [JsonProperty(PropertyName="heroicTimestamp")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? HeroicFirstKillUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date and time of the flex first kill in Utc
        /// A value of null means either the boss doesn't have flex mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        [JsonProperty(PropertyName="flexTimestamp")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? FlexFirstKillUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date and time of the LFR first kill in Utc
        /// A value of null means either the boss doesn't have LFR mode 
        /// or the boss was never killed in that mode.
        /// </summary>
        [JsonProperty(PropertyName="lfrTimestamp")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? LfrFirstKillUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date and time of the normal first kill in Utc
        /// A value of null means the boss was never killed in that mode.
        /// </summary>
        [JsonProperty(PropertyName="normalTimestamp")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime? NormalFirstKillUtc
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets string representation (for getting purposed)
        /// </summary>
        /// <returns> Gets string representation (for getting purposed) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} Normal:{1} Heroic:{2}", Name, NormalKills, HeroicKills);
        }
    }
}