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
    ///   Information about mounts collected by a character
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterMounts
    {
        /// <summary>
        ///   gets or sets the collection of collected mounts
        /// </summary>
        [JsonProperty(PropertyName="collected")]
        public IList<Mount> Collected
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the number of collected mounts
        /// </summary>
        [JsonProperty(PropertyName="numCollected")]
        public int CollectedCount
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets number of not collected mounts
        /// </summary>
        [JsonProperty(PropertyName="numNotCollected")]
        public int NotCollectedCount
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
            return CollectedCount + " mounts collected";
        }
    }
}