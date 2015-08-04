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
using System.Globalization;
using System.Linq;
using System.Text;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// A character career statistic
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterStatistic
    {
        /// <summary>
        /// Get or sets statistic id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the statistic name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the statistic is character wealth statistic. 
        /// This will always be false because Blizzard doesn't make wealth statistic public
        /// </summary>
        [JsonProperty(PropertyName="money")]
        public bool IsMoney
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the time where the statistic was last update in UTC
        /// </summary>
        [JsonProperty(PropertyName="lastUpdated")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTimeOffset LastUpdatedTime
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of the statistic
        /// </summary>
        /// <remarks>
        /// I haven't seen any statistic that has non-integer values, a long may be sufficient.
        /// However, I am using double just in case for future changes.
        /// </remarks>
        [JsonProperty(PropertyName="quantity")]
        public double Quantity
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the place/item/etc under which the highest value of the statistic was achieved.
        /// For example: Continent with the most Honorable Kills, Highest can be Northrend
        /// 
        /// </summary>
        [JsonProperty(PropertyName="highest")]
        public string Highest
        {
            get;
            set;
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + " = " + Quantity.ToString(CultureInfo.InvariantCulture);
        }
    }
}
