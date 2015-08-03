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
using Newtonsoft.Json.Converters;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents information about an item use spell or an item's proc
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemSpell
    {
        /// <summary>
        ///   Gets or sets the spell id
        /// </summary>
        [JsonProperty(PropertyName="spellId", Required = Required.Always)]
        public int SpellId
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item spell information
        /// </summary>
        [JsonProperty(PropertyName="spell")]
        public Spell Spell
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the number of times the spell can be used (0 means unlimited)
        /// </summary>
        [JsonProperty(PropertyName="nCharges", Required = Required.Always)]
        public int NumberOfCharges
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item is consumed when the spell is used
        /// </summary>
        [JsonProperty(PropertyName="consumable", Required = Required.Always)]
        public bool Consumable
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets how the item spell is triggered
        /// </summary>
        [JsonProperty(PropertyName="trigger", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemSpellTriggers Trigger
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's spell cooldown category (used to determine which items share CD with that item)
        /// </summary>
        [JsonProperty(PropertyName="categoryId", Required = Required.Always)]
        public int CooldownCategoryId
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
            return Spell == null ? "" : Spell.ToString();
        }
    }
}