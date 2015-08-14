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

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   challenge map
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChallengeMap
    {
        /// <summary>
        ///   gets or sets whether the map has a challenge mode
        /// </summary>
        [JsonProperty(PropertyName="hasChallengeMode")]
        public bool HasChallengeMode
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets id of the map
        /// </summary>
        [JsonProperty(PropertyName="id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets name of the map
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets slug for the map
        /// </summary>
        [JsonProperty(PropertyName="slug")]
        public string Slug
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets bronze criteria
        /// </summary>
        [JsonProperty(PropertyName="bronzeCriteria")]
        public ChallengeCompletionTime BronzeCriteria
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets silver criteria
        /// </summary>
        [JsonProperty(PropertyName="silverCriteria")]
        public ChallengeCompletionTime SilverCriteria
        {
            get;
            set;
        }


        /// <summary>
        ///   gets or sets gold criteria
        /// </summary>
        [JsonProperty(PropertyName="goldCriteria")]
        public ChallengeCompletionTime GoldCriteria
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
            return Name;
        }
    }
}