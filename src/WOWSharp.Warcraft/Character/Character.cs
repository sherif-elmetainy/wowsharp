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
using System.Collections.Generic;
using System.Globalization;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents character profile information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Character : ApiResponse
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
        ///   Gets or sets the character's battlegroup name
        /// </summary>
        [JsonProperty(PropertyName="battlegroup", Required = Required.Always)]
        public string BattleGroupName
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
        ///   Gets or sets the class id of the character in the Blizzard's talent calculator
        /// </summary>
        [JsonProperty(PropertyName="calcClass")]
        public string CalculatorClass
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's guild information. This can be null if the character doesn't belong to a guild, or the profile information was fetched without specified fetching guild information
        /// </summary>
        [JsonProperty(PropertyName="guild")]
        public CharacterGuild Guild
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the items currently equipped by the character. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="items")]
        public CharacterItems Items
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the current character's stats. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="stats")]
        public CharacterStats Stats
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets information about the character specialization and talent. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="talents")]
        public IList<CharacterTalents> Talents
        {
            get;
            set;
        }

        /// <summary>
        ///   Get or sets information about character's reputation is all factions the character interacted with. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="reputation")]
        public IList<CharacterReputation> Reputations
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets a collection or character's titles. %s is replaced by character's name when displaying the title. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="titles")]
        public IList<CharacterTitle> Titles
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets information about character's current professions and skil level. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="professions")]
        public CharacterProfessions Professions
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets information about character's appearance. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="appearance")]
        public CharacterAppearance Appearance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets a collection of character's mounts.  This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="mounts")]
        public CharacterMounts Mounts
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets a collection of character's pets. This can be null if the field is not requested while requesting the character profile data or if the character is a class not having pets.
        /// </summary>
        [JsonProperty(PropertyName="pets")]
        public CharacterPets Pets
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the current character's achievments. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="achievements")]
        public Achievements Achievements
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the current character's progression. This can be null if the field is not requested while requesting the character profile data.
        /// </summary>
        [JsonProperty(PropertyName="progression")]
        public CharacterProgression Progression
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the ids of the quests the character has completed
        /// </summary>
        [JsonProperty(PropertyName="quests")]
        public IList<int> CompletedQuestIds
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character Pvp stats
        /// </summary>
        [JsonProperty(PropertyName="pvp")]
        public CharacterPvpInformation Pvp
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets feeds
        /// </summary>
        [JsonProperty(PropertyName="feed")]
        public IList<FeedItem> Feed
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets hunter pets
        /// </summary>
        [JsonProperty(PropertyName="hunterPets")]
        public IList<HunterPet> HunterPets
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets pet slots
        /// </summary>
        [JsonProperty(PropertyName="petSlots")]
        public IList<CharacterPetSlot> PetSlots
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character total honorable kills
        /// </summary>
        [JsonProperty(PropertyName="totalHonorableKills")]
        public int TotalHonorableKills
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets the character career statistics. This will be null, 
        ///  unless Statistics enum flag is set when retreiving character data
        /// </summary>
        [JsonProperty(PropertyName="statistics")]
        public CharacterStatisticsCategory Statistics
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
            return $"{Name}@{Realm} Level {Level} {Gender} {Race} {Class}";
        }
    }
}