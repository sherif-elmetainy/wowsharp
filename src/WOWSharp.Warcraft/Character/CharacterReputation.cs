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
using System.Globalization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents a character's current standing with a faction
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterReputation
    {
        /// <summary>
        ///   gets or sets faction id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets faction name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the current standing
        /// </summary>
        [JsonProperty(PropertyName="standing", Required = Required.Always)]
        public Standing Standing
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the progress within the current standing
        /// </summary>
        [JsonProperty(PropertyName="value", Required = Required.Always)]
        public int Value
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the max value to reach the next standing
        /// </summary>
        [JsonProperty(PropertyName="max", Required = Required.Always)]
        public int Maximum
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
            return string.Format(CultureInfo.CurrentCulture, "{0} {1} {2}/{3}", Name, Standing, Value, Maximum);
        }
    }
}