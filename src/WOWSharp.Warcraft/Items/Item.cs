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
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents an in game item
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Item : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the item id
        /// </summary>
        [JsonProperty(PropertyName="id", Required = Required.Always)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the enchanting skill rank required to disenchant the item. If the value is -1 or null, it means the item cannot be disenchanted.
        /// </summary>
        [JsonProperty(PropertyName="disenchantingSkillRank")]
        public int? DisenchantingSkillRank
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item display info (probably this is the item's model).
        /// </summary>
        [JsonProperty(PropertyName="displayInfoId")]
        public int? DisplayInfoId
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item description
        /// </summary>
        [JsonProperty(PropertyName="description")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

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
        ///   Gets or sets the name description (heroic, raid finder, elite, etc)
        /// </summary>
        [JsonProperty(PropertyName="nameDescription")]
        public string NameDescription
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the color in which name description is displayed
        /// </summary>
        [JsonProperty(PropertyName="nameDescriptionColor")]
        public string NameDescriptionColor
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the max stack size for this item in inventory.
        /// </summary>
        [JsonProperty(PropertyName="stackable")]
        public int MaxStackSize
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the ids of the classes allowed to use/equip this item. A null value means all classes can use the item
        /// </summary>
        [JsonProperty(PropertyName="allowableClasses")]
        public IList<ClassKey> AllowableClasses
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item bind type
        /// </summary>
        [JsonProperty(PropertyName="itemBind")]
        public ItemBindType BindType
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's bonus stats
        /// </summary>
        [JsonProperty(PropertyName="bonusStats")]
        public IList<ItemStat> BonusStats
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's spells (procs and use effects)
        /// </summary>
        [JsonProperty(PropertyName="itemSpells")]
        public IList<ItemSpell> ItemSpells
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item buy from vendor price (the price a character would pay to buy the item from an NPC vendor)
        /// </summary>
        [JsonProperty(PropertyName="buyPrice")]
        public long BuyPrice
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item category
        /// </summary>
        [JsonProperty(PropertyName="itemClass")]
        public ItemCategory Category
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item sub category
        /// </summary>
        [JsonProperty(PropertyName="itemSubClass", Required = Required.Always)]
        public int SubcategoryId
        {
            get;
            set;
        }

        ///// <summary>
        /////   Gets or sets the item sub category
        ///// </summary>
        //public ItemSubcategory Subcategory
        //{
        //    get
        //    {
        //        unchecked
        //        {
        //            return (ItemSubcategory) (((long) Category << 32) | (uint) SubcategoryId);
        //        }
        //    }
        //    //internal set
        //    //{
        //    //    unchecked
        //    //    {
        //    //        this.SubcategoryId = (int)((long)value & 0xffffffffL);
        //    //        this.Category = (ItemCategory)(((long)value & 0xffff) >> 32);
        //    //    }
        //    //}
        //}

        /// <summary>
        ///   Gets or sets the container item slots (the value is zero if the item is not a container)
        /// </summary>
        [JsonProperty(PropertyName="containerSlots")]
        public int ContainerSlots
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the gem's information (this is null if the item is not a gem)
        /// </summary>
        [JsonProperty(PropertyName="gemInfo")]
        public GemInfo GemInfo
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
        ///   Gets or sets the item's inventory type
        /// </summary>
        [JsonProperty(PropertyName="inventoryType")]
        public ItemInventoryType? InventoryType
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item can be equipped
        /// </summary>
        [JsonProperty(PropertyName="equippable", Required = Required.Always)]
        public bool Equippable
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's level (ilvl)
        /// </summary>
        [JsonProperty(PropertyName="itemLevel")]
        public int ItemLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's set's id (if the item belongs to a set)
        /// </summary>
        [JsonProperty(PropertyName="itemSet")]
        public ItemSet ItemSet
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the max quantity of the item that can be carried by a character. If the value is zero, then max amount is unlimited.
        /// </summary>
        [JsonProperty(PropertyName="maxCount", Required = Required.Always)]
        public int MaxCount
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the maximum durability of the item. A value of zero means the item is indestructible.
        /// </summary>
        [JsonProperty(PropertyName="maxDurability", Required = Required.Always)]
        public int MaximumDurability
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of the faction required to obtain this item. If the value is zero, the item doesn't require a faction
        /// </summary>
        [JsonProperty(PropertyName="minFactionId", Required = Required.Always)]
        public int MinimumFactionId
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the minimum standing required with the faction to acquire the item
        /// </summary>
        [JsonProperty(PropertyName="minReputation", Required = Required.Always)]
        public Standing MinimumFactionStanding
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's quality
        /// </summary>
        [JsonProperty(PropertyName="quality", Required = Required.Always)]
        public ItemQuality ItemQuality
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item sell to vendor price (the price an NPC vendor would offer to buy the item)
        /// </summary>
        [JsonProperty(PropertyName="sellPrice", Required = Required.Always)]
        public long SellPrice
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets minimum character level required to use/equip the item
        /// </summary>
        [JsonProperty(PropertyName="requiredLevel", Required = Required.Always)]
        public int RequiredLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the profession required to use/equip the item
        /// </summary>
        [JsonProperty(PropertyName="requiredSkill", Required = Required.Always)]
        public Skill RequiredProfession
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the minumum skill rank required to use/equip the item
        /// </summary>
        [JsonProperty(PropertyName="requiredSkillRank", Required = Required.Always)]
        public int RequiredProfessionRank
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's socket information
        /// </summary>
        [JsonProperty(PropertyName="socketInfo")]
        public SocketInfo SocketInfo
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item source
        /// </summary>
        [JsonProperty(PropertyName="itemSource")]
        public ItemSource Source
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [JsonProperty(PropertyName="baseArmor", Required = Required.Always)]
        public int BaseArmor
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item's base armor
        /// </summary>
        [JsonProperty(PropertyName="armor", Required = Required.Always)]
        public int Armor
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the item has the "heroic" tooltip
        /// </summary>
        [JsonProperty(PropertyName="heroicTooltip")]
        public bool HeroicTooltip
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets whether the item has sockets
        /// </summary>
        [JsonProperty(PropertyName="hasSockets", Required = Required.Always)]
        public bool HasSockets
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets whether the item can be sold in the auction house.
        /// </summary>
        [JsonProperty(PropertyName="isAuctionable", Required = Required.Always)]
        public bool IsAuctionable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the item is upgradable
        /// </summary>
        [JsonProperty(PropertyName="upgradable")]
        public bool IsUpgradable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets item's tooltip parameters
        /// </summary>
        [JsonProperty(PropertyName="tooltipParams")]
        public EquippedItemParameters TooltipParameters
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