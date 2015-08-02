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
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// Class talent information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ClassTalentInfo
    {
        /// <summary>
        ///   gets or sets name of the class
        /// </summary>
        [JsonProperty(PropertyName="class")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClassKey ClassKey
        {
            get;
            set;
        }


        /// <summary>
        ///   gets or sets glyphs that this class can learn
        /// </summary>
        [JsonProperty(PropertyName="glyphs")]
        public IList<CharacterGlyph> Glyphs
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets pet specializations that a hunter pet can learn
        ///   Will be null for classes other than hunter.
        /// </summary>
        [JsonProperty(PropertyName="petSpecs")]
        public IList<Specialization> PetSpecializations
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets specializations that this class can learn
        /// </summary>
        [JsonProperty(PropertyName="specs")]
        public IList<Specialization> Specializations
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets talents
        /// </summary>
        public IList<IList<CharacterTalent>> Talents
        {
            get;
            set;
        }
    }
}