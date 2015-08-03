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
    ///   Represents information about a glyph being used by a character
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterGlyph
    {
        /// <summary>
        ///   gets or sets glyph id
        /// </summary>
        [JsonProperty(PropertyName="glyph", Required = Required.Always)]
        public int GlyphId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets item id (of the glyph)
        /// </summary>
        [JsonProperty(PropertyName="item", Required = Required.Always)]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets glyph name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets glyph's icon
        /// </summary>
        [JsonProperty(PropertyName="icon", Required = Required.Always)]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets glyph type id (no idea what that is)
        /// </summary>
        [JsonProperty(PropertyName="typeId")]
        public int TypeId
        {
            get;
            set;
        }

        /// <summary>
        ///   Returns the name of the glyph (for debugging purposes)
        /// </summary>
        /// <returns> Returns the name of the glyph (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}