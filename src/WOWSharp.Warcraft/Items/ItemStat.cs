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
    ///   Represents an item bonus stat
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemStat
    {
        /// <summary>
        ///   Gets or sets the bonus stat type
        /// </summary>
        [JsonProperty(PropertyName="stat", Required = Required.Always)]
        public ItemStatType StatType
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the bonus stat amount
        /// </summary>
        [JsonProperty(PropertyName="amount", Required = Required.Always)]
        public int Amount
        {
            get;
            set;
        }


        /// <summary>
        ///   Gets or sets whether the stat is reforged. this is true for the reforged to stat (the stat that is increased)
        /// </summary>
        [JsonProperty(PropertyName="reforged")]
        public bool IsReforged
        {
            get;
            set;
        }

        /// <summary>
        ///    Gets or sets the reforged amount i.e. the stat that is decreased when the item is reforged (this should be negative)
        /// </summary>
        [JsonProperty(PropertyName="reforgedAmount")]
        public int ReforgedAmount
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
            return string.Format(CultureInfo.CurrentCulture, "{0}: {1}", StatType, Amount);
        }
    }
}