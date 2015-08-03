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
using System.Collections.Generic;
using System.Globalization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents a character's talent specialization
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterTalents
    {
        /// <summary>
        ///   Gets or sets whether this talent specialization is the currently selected specialization
        /// </summary>
        [JsonProperty(PropertyName="selected")]
        public bool IsSelected
        {
            get;
            set;
        }

        /// <summary>
        ///   The characters talent build
        /// </summary>
        [JsonProperty(PropertyName="talents")]
        public IList<CharacterTalent> Build
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets information about the glyphs used in this specialization
        /// </summary>
        [JsonProperty(PropertyName="glyphs")]
        public CharacterGlyphs Glyphs
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the specialization for the character
        /// </summary>
        [JsonProperty(PropertyName="spec")]
        public Specialization Specialization
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        [JsonProperty(PropertyName="calcTalent")]
        public string CalculatorTalent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        [JsonProperty(PropertyName="calcSpec")]
        public string CalculatorSpecialization
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets a string that can be used to make a url for character's talent on B.NET site calculator
        /// </summary>
        [JsonProperty(PropertyName="calcGlyph")]
        public string CalculatorGlyphs
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
            return string.Format(CultureInfo.CurrentCulture, "{0}", Specialization == null ? "" : Specialization.Name);
        }
    }
}