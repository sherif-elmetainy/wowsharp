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
using Newtonsoft.Json.Converters;
using System;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// Guild news feed entry
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GuildNewsItem
    {
        /// <summary>
        ///   gets or sets achievement
        /// </summary>
        [JsonProperty(PropertyName="achievement")]
        public Achievement Achievement
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets item id
        /// </summary>
        [JsonProperty(PropertyName="itemId")]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets name of the character to which the news item is related
        /// </summary>
        [JsonProperty(PropertyName="character")]
        public string CharacterName
        {
            get;
            set;
        }

        /// <summary>
        ///   Event date in Utc
        /// </summary>
        [JsonProperty(PropertyName="timestamp")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTime DateTimeUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Level up
        /// </summary>
        [JsonProperty(PropertyName="levelUp")]
        public int LevelUp
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets name of the type of the news item
        /// </summary>
        [JsonProperty(PropertyName="type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GuildNewsItemType GuildNewsItemType
        {
            get;
            set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            switch (GuildNewsItemType)
            {
                case GuildNewsItemType.GuildAchievement:
                    return "Guild Achievement: " + CharacterName + " " + Achievement;
                case GuildNewsItemType.PlayerAchievement:
                    return "Player Achievement: " + CharacterName + " " + Achievement;
                case GuildNewsItemType.ItemPurchase:
                    return "Item Purchase: " + CharacterName + ItemId;
                case GuildNewsItemType.ItemLoot:
                    return "Item Loot: " + CharacterName + ItemId;
                case GuildNewsItemType.ItemCraft:
                    return "Item Craft: " + CharacterName + ItemId;
                case GuildNewsItemType.GuildLevelUp:
                    return "Guild Level: " + LevelUp;
                default:
                    return GuildNewsItemType.ToString();
            }
        }
    }
}