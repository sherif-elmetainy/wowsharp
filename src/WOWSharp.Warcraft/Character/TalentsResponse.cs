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

using Newtonsoft.Json;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   response for talents API call
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TalentsResponse : ApiResponse
    {
        /// <summary>
        ///   gets or sets warrior talents
        /// </summary>
        [JsonProperty(PropertyName="1")]
        public ClassTalentInfo Warrior
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets paladin talents
        /// </summary>
        [JsonProperty(PropertyName="2")]
        public ClassTalentInfo Paladin
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets hunter talents
        /// </summary>
        [JsonProperty(PropertyName="3")]
        public ClassTalentInfo Hunter
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets rogue talents
        /// </summary>
        [JsonProperty(PropertyName="4")]
        public ClassTalentInfo Rogue
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets priest talents
        /// </summary>
        [JsonProperty(PropertyName="5")]
        public ClassTalentInfo Priest
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets death knight talents
        /// </summary>
        [JsonProperty(PropertyName="6")]
        public ClassTalentInfo DeathKnight
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets shaman talents
        /// </summary>
        [JsonProperty(PropertyName="7")]
        public ClassTalentInfo Shaman
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets mage talents
        /// </summary>
        [JsonProperty(PropertyName="8")]
        public ClassTalentInfo Mage
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets warlock talents
        /// </summary>
        [JsonProperty(PropertyName="9")]
        public ClassTalentInfo Warlock
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets monk talents
        /// </summary>
        [JsonProperty(PropertyName="10")]
        public ClassTalentInfo Monk
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets druid talents
        /// </summary>
        [JsonProperty(PropertyName="11")]
        public ClassTalentInfo Druid
        {
            get;
            set;
        }
    }
}