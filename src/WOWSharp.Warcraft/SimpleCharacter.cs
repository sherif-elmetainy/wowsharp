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

using System.Globalization;
using Newtonsoft.Json;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Challenge mode group member character information (this is the same info as Character class),
    ///   however rather than returning guild member as guild info, this API returns guild as a string containing guild name
    ///   hence the different class
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SimpleCharacter
    {
        /// <summary>
        ///   Gets or sets the realm name to which the character belongs
        /// </summary>
        [JsonProperty(PropertyName="realm", Required = Required.Always)]
        public string Realm
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the realm name guild to which the character belongs 
        ///   (can be different from realm in case of connected realms)
        /// </summary>
        [JsonProperty(PropertyName="guildRealm")]
        public string GuildRealm
        {
            get;
            set;
        }


        /// <summary>
        ///   Gets or sets the character name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character battle group name
        /// </summary>
        [JsonProperty(PropertyName="battlegroup")]
        public string BattleGroupName
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character level
        /// </summary>
        [JsonProperty(PropertyName="level", Required = Required.Always)]
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the thumbnail image for the character
        /// </summary>
        [JsonProperty(PropertyName="thumbnail", Required = Required.Always)]
        public string Thumbnail
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the race id of the character
        /// </summary>
        [JsonProperty(PropertyName="race", Required = Required.Always)]
        public Race Race
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets the character faction
        /// </summary>
        public Faction Faction
        {
            get
            {
                if (Race == Race.NeutralPandaren)
                    return Faction.Neutral;
                return Race == Race.Worgen
                       || Race == Race.NightElf
                       || Race == Race.Human
                       || Race == Race.Gnome
                       || Race == Race.Dwarf
                       || Race == Race.Draenei
                       || Race == Race.AlliancePandaren
                           ? Faction.Alliance
                           : Faction.Horde;
            }
        }

        /// <summary>
        ///   Gets or sets the total achievevement points for the character
        /// </summary>
        [JsonProperty(PropertyName="achievementPoints", Required = Required.Always)]
        public int AchievementPoints
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's gender
        /// </summary>
        [JsonProperty(PropertyName="gender", Required = Required.Always)]
        public CharacterGender Gender
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the class id of the character
        /// </summary>
        [JsonProperty(PropertyName="class", Required = Required.Always)]
        public ClassKey Class
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's guild information. This can be null if the character doesn't belong to a guild, or the profile information was fetched without specified fetching guild information
        /// </summary>
        [JsonProperty(PropertyName="guild")]
        public string Guild
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the spec for the group member
        /// </summary>
        [JsonProperty(PropertyName="spec")]
        public Specialization Specialization
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
            return string.Format(CultureInfo.CurrentCulture, "{0}@{1} Level {2} {3} {4} {5}",
                                 Name, Realm, Level, Gender, Race, Class);
        }
    }
}