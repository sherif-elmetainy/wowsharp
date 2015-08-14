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
    ///   information about a challenge
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Challenge
    {
        /// <summary>
        ///   gets or sets groups that completed the challenge
        /// </summary>
        [JsonProperty(PropertyName="groups")]
        public IList<ChallengeGroup> Groups
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets map
        /// </summary>
        [JsonProperty(PropertyName="map")]
        public ChallengeMap Map
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets realm
        /// </summary>
        [JsonProperty(PropertyName="realm")]
        public Realm Realm
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
            return $"{Map} - {Realm}: {Groups?.Count ?? 0} groups";
        }
    }
}