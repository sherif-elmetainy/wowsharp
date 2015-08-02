// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// Represents information about a character's PVP performance
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterPvpBracketInformation
    {
        /// <summary>
        /// Gets or sets the player's character rating
        /// </summary>
        [JsonProperty(PropertyName="rating", Required = Required.Always)]
        public int Rating
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current PVP season
        /// </summary>
        [JsonProperty(PropertyName="seasonLost", Required = Required.Always)]
        public int SeasonLosses
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current PVP season
        /// </summary>
        [JsonProperty(PropertyName="seasonWon", Required = Required.Always)]
        public int SeasonWins
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets number of games played by the player's character during the current PVP season
        /// </summary>
        [JsonProperty(PropertyName="seasonPlayed", Required = Required.Always)]
        public int SeasonPlayed
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current week
        /// </summary>
        [JsonProperty(PropertyName="weeklyLost", Required = Required.Always)]
        public int WeeklyLosses
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current week
        /// </summary>
        [JsonProperty(PropertyName="weeklyWon", Required = Required.Always)]
        public int WeeklyWins
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets number of games played by the player's character during the current week
        /// </summary>
        [JsonProperty(PropertyName="weeklyPlayed", Required = Required.Always)]
        public int WeeklyPlayed
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets the PvP bracket type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName="slug", Required = Required.Always)]
        public PvpBracket PvpBracket
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
            return string.Format(CultureInfo.CurrentCulture, "{0} rating: {1}", PvpBracket, Rating);
        }
    }
}
