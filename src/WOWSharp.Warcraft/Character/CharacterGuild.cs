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
using System.Globalization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents character guild information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterGuild
    {
        /// <summary>
        ///   Gets or sets the name of the guild
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the realm to which the guild belongs
        /// </summary>
        [JsonProperty(PropertyName="realm", Required = Required.Always)]
        public string Realm
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the guild's battlegroup name
        /// </summary>
        [JsonProperty(PropertyName="battlegroup", Required = Required.Always)]
        public string BattleGroupName
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the guild's level
        /// </summary>
        [JsonProperty(PropertyName="level", Required = Required.Always)]
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the number of achievement points the guild has earned
        /// </summary>
        [JsonProperty(PropertyName="achievementPoints", Required = Required.Always)]
        public int AchievementPoints
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets information about the guild's emblem
        /// </summary>
        [JsonProperty(PropertyName="emblem")]
        public GuildEmblem Emblem
        {
            get;
            set;
        }

        /// <summary>
        /// Guild's member count
        /// </summary>
        [JsonProperty(PropertyName="members")]
        public int MemberCount
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
            return string.Format(CultureInfo.CurrentCulture, "Guild {0}@{1}", Name, Realm);
        }
    }
}