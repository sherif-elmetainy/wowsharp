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
using System.Collections.Generic;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents an achievement
    /// </summary>
    [BattleNetCachePolicy(CacheDurationSeconds = 3600, UseSlidingExpiration = true, ShouldCheckIfCachedEntriesAreModified = true)]
    [JsonObject(MemberSerialization.OptIn)]
    public class Achievement : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement title
        /// </summary>
        [JsonProperty(PropertyName="title", Required = Required.Always)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement's icon
        /// </summary>
        [JsonProperty(PropertyName="icon")]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement points
        /// </summary>
        [JsonProperty(PropertyName="points")]
        public int Points
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement description
        /// </summary>
        [JsonProperty(PropertyName="description", Required = Required.Always)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement's reward
        /// </summary>
        [JsonProperty(PropertyName="reward")]
        public string Reward
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement's reward item
        /// </summary>
        [JsonProperty(PropertyName="rewardItems")]
        public IList<RewardItem> RewardItems
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets Criteria for the achievement
        /// </summary>
        [JsonProperty(PropertyName="criteria")]
        public IList<AchievementCriterion> Criteria
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets whether the achievement is account wide
        /// </summary>
        [JsonProperty(PropertyName="accountWide")]
        public bool AccountWide
        {
            get;
            set;
        }

        /// <summary>
        ///  Achievement's faction
        /// </summary>
        [JsonProperty(PropertyName="factionId", Required = Required.Always)]
        public Faction Faction
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
            return Title;
        }
    }
}