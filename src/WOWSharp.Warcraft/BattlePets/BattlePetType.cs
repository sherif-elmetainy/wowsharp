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

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   information about a battle pet type
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BattlePetType
    {
        /// <summary>
        ///   gets or sets id
        /// </summary>
        [JsonProperty(PropertyName="id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets key (culture independent name)
        /// </summary>
        [JsonProperty(PropertyName="key")]
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets name
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets strong against type id
        /// </summary>
        [JsonProperty(PropertyName="strongAgainstId")]
        public int StrongAgainstId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets type ability id
        /// </summary>
        [JsonProperty(PropertyName="typeAbilityId")]
        public int TypeAbilityId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets Weak against id
        /// </summary>
        [JsonProperty(PropertyName="weakAgainstId")]
        public int WeakAgainstId
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
            return Name;
        }
    }
}