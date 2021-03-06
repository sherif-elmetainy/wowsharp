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

using System.Globalization;
using Newtonsoft.Json;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// Information about a character's performance in different PVP brackets
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterPvpBrackets
    {
        /// <summary>
        /// Gets or sets characters PVP 2v2 bracket information
        /// </summary>
        [JsonProperty(PropertyName="ARENA_BRACKET_2v2", Required = Required.Always)]
        public CharacterPvpBracketInformation Arena2V2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets characters PVP 3v3 bracket information
        /// </summary>
        [JsonProperty(PropertyName="ARENA_BRACKET_3v3", Required = Required.Always)]
        public CharacterPvpBracketInformation Arena3V3
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets characters PVP 5v5 bracket information
        /// </summary>
        [JsonProperty(PropertyName="ARENA_BRACKET_5v5", Required = Required.Always)]
        public CharacterPvpBracketInformation Arena5V5
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets characters PVP Rated battle ground bracket information
        /// </summary>
        [JsonProperty(PropertyName="ARENA_BRACKET_RBG", Required = Required.Always)]
        public CharacterPvpBracketInformation RatedBattleground
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}, {1}, {2}, {3}", Arena2V2, Arena3V3, Arena5V5, RatedBattleground);
        }
    }
}
