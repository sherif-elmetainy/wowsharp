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
using System.Collections.Generic;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents information about a character's equipped item
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class EquippedItem
    {
        /// <summary>
        ///   Gets or sets the item's icon
        /// </summary>
        [JsonProperty(PropertyName="icon", Required = Required.Always)]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's level 
        /// </summary>
        [JsonProperty(PropertyName="itemLevel", Required = Required.Always)]
        public int ItemLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the item name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item quality
        /// </summary>
        [JsonProperty(PropertyName="quality", Required = Required.Always)]
        public ItemQuality Quality
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets information about gems, enchants, reforging and tinkers
        /// </summary>
        [JsonProperty(PropertyName="tooltipParams")]
        public EquippedItemParameters Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the equipped item stats
        /// </summary>
        [JsonProperty(PropertyName="stats")]
        public IList<ItemStat> Stats
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets information about the weapon (if the item is a weapon)
        /// </summary>
        [JsonProperty(PropertyName="weaponInfo")]
        public WeaponInfo WeaponInfo
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [JsonProperty(PropertyName="armor")]
        public int Armor
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