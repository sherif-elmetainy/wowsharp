﻿#region LICENSE
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
using Newtonsoft.Json.Converters;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Information about character class
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterClass
    {
        /// <summary>
        ///   Gets or sets class id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public ClassKey Class
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets class mask (No Idea what that's used for)
        /// </summary>
        [JsonProperty(PropertyName="mask", Required = Required.Always)]
        public int Mask
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the class' power type
        /// </summary>
        [JsonProperty(PropertyName="powerType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerType PowerType
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the class name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets class name
        /// </summary>
        /// <returns> Gets class name (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}