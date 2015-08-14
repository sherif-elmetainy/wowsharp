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

using System.Collections.Generic;
using Newtonsoft.Json;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents an achievement category
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AchievementCategory
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
        ///   Gets or sets the achievement category name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the subcategories of this category
        /// </summary>
        [JsonProperty(PropertyName="categories")]
        public IList<AchievementCategory> Categories
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievements under this category
        /// </summary>
        [JsonProperty(PropertyName="achievements")]
        public IList<Achievement> Achievements
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
            return Name;
        }
    }
}