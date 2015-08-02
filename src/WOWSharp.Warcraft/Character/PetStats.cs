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
using System.Globalization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Pets stats
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PetStats
    {
        /// <summary>
        ///   gets or sets breed id
        /// </summary>
        [JsonProperty(PropertyName="breedId")]
        public int BreedId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets health points
        /// </summary>
        [JsonProperty(PropertyName="health")]
        public int Health
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets level
        /// </summary>
        [JsonProperty(PropertyName="level")]
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets pet's quality
        /// </summary>
        [JsonProperty(PropertyName="petQualityId")]
        public ItemQuality Quality
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets power
        /// </summary>
        [JsonProperty(PropertyName="power")]
        public int Power
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets species id
        /// </summary>
        [JsonProperty(PropertyName="speciesId")]
        public int SpeciesId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets pet's speed
        /// </summary>
        [JsonProperty(PropertyName="speed")]
        public int Speed
        {
            get;
            set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return "Level " + Level.ToString(CultureInfo.InvariantCulture);
        }
    }
}