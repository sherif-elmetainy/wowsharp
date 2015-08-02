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

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   A characters specialization
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Specialization
    {
        /// <summary>
        ///   Gets or sets the name of the spec
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the role of the spec
        /// </summary>
        [JsonProperty(PropertyName="role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CharacterRoles Role
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the name of the background image of the spec
        /// </summary>
        [JsonProperty(PropertyName="backgroundImage")]
        public string BackgroundImage
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the name of the icon image of the spec
        /// </summary>
        [JsonProperty(PropertyName="icon")]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the description of the spec
        /// </summary>
        [JsonProperty(PropertyName="description")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the order of the spec within the other specs of the class
        /// </summary>
        [JsonProperty(PropertyName="order")]
        public int Order
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