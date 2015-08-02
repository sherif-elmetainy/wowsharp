// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   An achievement criteria
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AchievementCriterion
    {
        /// <summary>
        ///   Achievement criteria
        /// </summary>
        [JsonProperty(PropertyName="id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   Achievement description
        /// </summary>
        [JsonProperty(PropertyName="description")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        ///   Order Index
        /// </summary>
        [JsonProperty(PropertyName="orderIndex")]
        public int OrderIndex
        {
            get;
            set;
        }

        /// <summary>
        ///   Max
        /// </summary>
        [JsonProperty(PropertyName="max")]
        public int Max
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
            return Description;
        }
    }
}