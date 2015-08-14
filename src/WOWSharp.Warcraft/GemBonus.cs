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
    ///   Represents gem's bonus
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GemBonus
    {
        /// <summary>
        ///   The socket bonus description (e.g. "+20 Agility and +20 Hit Rating")
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets source item id. This is the same as item id for the gem
        /// </summary>
        [JsonProperty(PropertyName="srcItemId", Required = Required.Always)]
        public int SourceItemId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets The required skill
        /// </summary>
        [JsonProperty(PropertyName="requiredSkillId", Required = Required.Always)]
        public Skill RequiredSkillId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the required skill rank
        /// </summary>
        [JsonProperty(PropertyName="requiredSkillRank", Required = Required.Always)]
        public int RequiredSkillRank
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the required gem's item level
        /// </summary>
        [JsonProperty(PropertyName="itemLevel", Required = Required.Always)]
        public int ItemLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the required level for the gem
        /// </summary>
        [JsonProperty(PropertyName="minLevel")]
        public int MinimumLevel
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