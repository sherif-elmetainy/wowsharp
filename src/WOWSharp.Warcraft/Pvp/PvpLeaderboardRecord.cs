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

using Newtonsoft.Json;
using System.Globalization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///  PVP Leader board entry (Arena or Battleground)
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PvpLeaderboardRecord
    {
        /// <summary>
        /// Gets or sets the player's character class
        /// </summary>
        [JsonProperty(PropertyName="classId", Required = Required.Always)]
        public ClassKey Class
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the player's character faction
        /// </summary>
        [JsonProperty(PropertyName="factionId", Required = Required.Always)]
        public Faction Faction
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the player's character gender
        /// </summary>
        [JsonProperty(PropertyName="genderId", Required = Required.Always)]
        public CharacterGender Gender
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the player's character name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the player's character race
        /// </summary>
        [JsonProperty(PropertyName="raceId", Required = Required.Always)]
        public Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the player's character ranking
        /// </summary>
        [JsonProperty(PropertyName="ranking", Required = Required.Always)]
        public int Ranking
        {
            get;
            set;
        }

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
        /// Gets or sets the player's character realm Id (the Realm ID is not used anywhere else in the APIs AFAIK)
        /// </summary>
        [JsonProperty(PropertyName="realmId", Required = Required.Always)]
        public int RealmId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the player's character realm name
        /// </summary>
        [JsonProperty(PropertyName="realmName", Required = Required.Always)]
        public string RealmName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the player's character realm slug
        /// </summary>
        [JsonProperty(PropertyName="realmSlug", Required = Required.Always)]
        public string RealmSlug
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets player's character specialization ID
        /// </summary>
        [JsonProperty(PropertyName="specId", Required = Required.Always)]
        public int SpecId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current PVP season
        /// </summary>
        [JsonProperty(PropertyName="seasonLosses", Required = Required.Always)]
        public int SeasonLosses
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current PVP season
        /// </summary>
        [JsonProperty(PropertyName="seasonWins", Required = Required.Always)]
        public int SeasonWins
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets number of games lost by the player's character during the current week
        /// </summary>
        [JsonProperty(PropertyName="weeklyLosses", Required = Required.Always)]
        public int WeeklyLosses
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets number of games won by the player's character during the current week
        /// </summary>
        [JsonProperty(PropertyName="weeklyWins", Required = Required.Always)]
        public int WeeklyWins
        {
            get;
            set;
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}:{1}@{2}", Ranking, Name, RealmName);
        }
    }
}
