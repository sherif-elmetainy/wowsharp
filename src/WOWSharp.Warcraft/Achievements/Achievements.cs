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
using System;
using System.Collections.Generic;
using System.Linq;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents character's or guild's achievement
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Achievements
    {
        /// <summary>
        ///   Gets or sets the Ids of all achievements completed
        /// </summary>
        [JsonProperty(PropertyName="achievementsCompleted", Required = Required.Always)]
        public IList<int> AchievementsCompleted
        {
            get;
            set;
        }


        /// <summary>
        ///   Gets the dates in UTC at which the achievements where completed
        /// </summary>
        [JsonProperty(PropertyName="achievementsCompletedTimestamp", Required = Required.Always)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public IList<DateTimeOffset> AchievementsCompletedDates
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the ids of achievements criteria completed
        /// </summary>
        [JsonProperty(PropertyName="criteria", Required = Required.Always)]
        public IList<int> Criteria
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the quantity of criteria that are still in progress
        /// </summary>
        [JsonProperty(PropertyName="criteriaQuantity", Required = Required.Always)]
        public IList<long> CriteriaQuantity
        {
            get;
            set;
        }

        /// <summary>
        ///   gets the dates (in UTC) at the criteria was last updates
        /// </summary>
        [JsonProperty(PropertyName="criteriaTimestamp", Required = Required.Always)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public IList<DateTimeOffset> CriteriaDates
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets the dates (in UTC) at which the criteria were created
        /// </summary>
        [JsonProperty(PropertyName="criteriaCreated", Required = Required.Always)]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public IList<DateTimeOffset> CriteriaCreatedDates
        {
            get;
            set;
        }
    }
}