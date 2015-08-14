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
using System.Linq;
using Newtonsoft.Json;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents information about character's equipped items
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterItems
    {
        /// <summary>
        ///   Gets or sets the average item level of the best equiment of the character
        /// </summary>
        [JsonProperty(PropertyName = "averageItemLevel", Required = Required.Always, Order = 0)]
        public int AverageItemLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the average item level of the items currently equipped by the character
        /// </summary>
        [JsonProperty(PropertyName="averageItemLevelEquipped", Required = Required.Always)]
        public int AverageItemLevelEquipped
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the back slot by the character
        /// </summary>
        [JsonProperty(PropertyName="back")]
        public EquippedItem Back
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the chest slot by the character
        /// </summary>
        [JsonProperty(PropertyName="chest")]
        public EquippedItem Chest
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the feet slot by the character
        /// </summary>
        [JsonProperty(PropertyName="feet")]
        public EquippedItem Feet
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the finger 1 slot by the character
        /// </summary>
        [JsonProperty(PropertyName="finger1")]
        public EquippedItem Finger1
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the finger 2 slot by the character
        /// </summary>
        [JsonProperty(PropertyName="finger2")]
        public EquippedItem Finger2
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the hands slot by the character
        /// </summary>
        [JsonProperty(PropertyName="hands")]
        public EquippedItem Hands
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the head slot by the character
        /// </summary>
        [JsonProperty(PropertyName="head")]
        public EquippedItem Head
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the legs slot by the character
        /// </summary>
        [JsonProperty(PropertyName="legs")]
        public EquippedItem Legs
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the main hand slot by the character
        /// </summary>
        [JsonProperty(PropertyName="mainHand")]
        public EquippedItem MainHand
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the off hand slot by the character
        /// </summary>
        [JsonProperty(PropertyName="offHand")]
        public EquippedItem Offhand
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the neck slot by the character
        /// </summary>
        [JsonProperty(PropertyName="neck")]
        public EquippedItem Neck
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the shirt slot by the character
        /// </summary>
        [JsonProperty(PropertyName="shirt")]
        public EquippedItem Shirt
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the shoulder slot by the character
        /// </summary>
        [JsonProperty(PropertyName="shoulder")]
        public EquippedItem Shoulder
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the tabard slot by the character
        /// </summary>
        [JsonProperty(PropertyName="tabard")]
        public EquippedItem Tabard
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 1 slot by the character
        /// </summary>
        [JsonProperty(PropertyName="trinket1")]
        public EquippedItem Trinket1
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the trinket 2 slot by the character
        /// </summary>
        [JsonProperty(PropertyName="trinket2")]
        public EquippedItem Trinket2
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the waist slot by the character
        /// </summary>
        [JsonProperty(PropertyName="waist")]
        public EquippedItem Waist
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item equipped in the wrist slot by the character
        /// </summary>
        [JsonProperty(PropertyName="wrist")]
        public EquippedItem Wrist
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets the item equipped in the specified slot
        /// </summary>
        /// <param name="slotName"> name of the equipment slot </param>
        /// <returns> The item equipped by the character in the specified slot </returns>
        public EquippedItem this[EquipmentSlot slotName]
        {
            get
            {
                switch (slotName)
                {
                    case EquipmentSlot.Head:
                        return Head;
                    case EquipmentSlot.Neck:
                        return Neck;
                    case EquipmentSlot.Shoulder:
                        return Shoulder;
                    case EquipmentSlot.Chest:
                        return Chest;
                    case EquipmentSlot.Back:
                        return Back;
                    case EquipmentSlot.Shirt:
                        return Shirt;
                    case EquipmentSlot.Wrist:
                        return Wrist;
                    case EquipmentSlot.Hands:
                        return Hands;
                    case EquipmentSlot.Waist:
                        return Waist;
                    case EquipmentSlot.Legs:
                        return Legs;
                    case EquipmentSlot.Feet:
                        return Feet;
                    case EquipmentSlot.Finger1:
                        return Finger1;
                    case EquipmentSlot.Finger2:
                        return Finger2;
                    case EquipmentSlot.Trinket1:
                        return Trinket1;
                    case EquipmentSlot.Trinket2:
                        return Trinket2;
                    case EquipmentSlot.MainHand:
                        return MainHand;
                    case EquipmentSlot.Offhand:
                        return Offhand;
                    case EquipmentSlot.Tabard:
                        return Tabard;
                }
                return null;
            }
        }

        /// <summary>
        ///   Gets all items equipped by the character
        /// </summary>
        public IEnumerable<EquippedItem> AllItems
        {
            get
            {
                return EnumHelper<EquipmentSlot>.GetValues()
                    .Select(slot => this[slot])
                    .Where(equippedItem => equippedItem != null);
            }
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Average ilvl {0}, Equipped {1}", AverageItemLevel,
                                 AverageItemLevelEquipped);
        }
    }
}