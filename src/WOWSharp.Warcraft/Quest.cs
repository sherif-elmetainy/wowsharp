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
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents quest information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Quest : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the achievement id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the achievement title
        /// </summary>
        [JsonProperty(PropertyName="title", Required = Required.Always)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the required level
        /// </summary>
        [JsonProperty(PropertyName="reqLevel")]
        public int RequiredLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the number of suggested party members
        /// </summary>
        [JsonProperty(PropertyName="suggestedPartyMembers")]
        public int SuggestedPartyMembers
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the quest's category
        /// </summary>
        [JsonProperty(PropertyName="category")]
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the quest's level (I am guessing that's the recommended level?)
        /// </summary>
        [JsonProperty(PropertyName="level")]
        public int Level
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
            return Title;
        }
    }
}