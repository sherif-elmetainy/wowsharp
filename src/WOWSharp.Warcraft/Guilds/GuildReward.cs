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

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents a guild reward
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GuildReward
    {
        /// <summary>
        ///   Gets or sets the reward's minimum guild level required
        /// </summary>
        [JsonProperty(PropertyName="minGuildLevel", Required = Required.Always)]
        public int MinimumGuildLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the reward's minumum guild reputation
        /// </summary>
        [JsonProperty(PropertyName="minGuildRepLevel", Required = Required.Always)]
        public Standing MinimumGuildReputationLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the races for which the reward is available
        /// </summary>
        [JsonProperty(PropertyName="races")]
        public IList<Race> Races
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement required to unlock the reward
        /// </summary>
        [JsonProperty(PropertyName="achievement")]
        public Achievement Achievement
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the reward item
        /// </summary>
        [JsonProperty(PropertyName="item")]
        public RewardItem RewardItem
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
            return RewardItem == null ? "" : RewardItem.ToString();
        }
    }
}