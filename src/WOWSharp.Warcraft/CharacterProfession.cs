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
using System.Globalization;
using Newtonsoft.Json;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents a character's profession
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterProfession
    {
        /// <summary>
        ///   gets or sets profession id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public Skill Id
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the profession name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the profession icon
        /// </summary>
        [JsonProperty(PropertyName="icon", Required = Required.Always)]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the profession rank reached by the character
        /// </summary>
        [JsonProperty(PropertyName="rank", Required = Required.Always)]
        public int Rank
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the profession's max skill level (the API seems to return zero for that field)
        /// </summary>
        [JsonProperty(PropertyName="max", Required = Required.Always)]
        public int Maximum
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the list of recipes learned by the character
        /// </summary>
        [JsonProperty(PropertyName="recipes", Required = Required.Always)]
        public IList<int> Recipes
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
            return string.Format(CultureInfo.CurrentCulture, "{0} {1}/{2} {3} Recipes", Name, Rank, Maximum, Recipes?.Count ?? 0);
        }
    }
}