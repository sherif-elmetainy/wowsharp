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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Base class for character and guild feeds
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FeedItem
    {
        /// <summary>
        ///   gets or sets name of the feed item type
        /// </summary>
        [JsonProperty(PropertyName="type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedItemType FeedItemType
        {
            get;
            set;
        }

        /// <summary>
        ///   gets the time the event occured
        /// </summary>
        [JsonProperty(PropertyName="timestamp")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTimeOffset Time
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
        ///   gets or sets achievement
        /// </summary>
        [JsonProperty(PropertyName="achievement")]
        public Achievement Achievement
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets criteria completed
        /// </summary>
        [JsonProperty(PropertyName="criteria")]
        public AchievementCriterion Criteria
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether this is a feat of stregth
        /// </summary>
        [JsonProperty(PropertyName="featOfStrength")]
        public bool FeatOfStrength
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the name of the event
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets quantity (number of times the boss was killed)
        /// </summary>
        [JsonProperty(PropertyName="quantity")]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        ///   string representation for debug purposes
        /// </summary>
        /// <returns> string representation for debug purposes </returns>
        public override string ToString()
        {
            switch (FeedItemType)
            {
                case FeedItemType.BossKill:
                    return FeedItemType.ToString() + ": " + Achievement.Description;
                case FeedItemType.Achievement:
                    return FeedItemType.ToString() + ": " + Achievement.Description;
                case FeedItemType.Loot:
                    return FeedItemType.ToString() + ": " + ItemId;
                case FeedItemType.Criteria:
                    return FeedItemType.ToString() + ": " + Criteria.Description;
                default:
                    return FeedItemType.ToString();
            }
        }
    }
}