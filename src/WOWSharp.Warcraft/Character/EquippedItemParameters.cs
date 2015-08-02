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
using System.Collections.Generic;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents information about item's gems, enchants and reforging
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class EquippedItemParameters
    {
        /// <summary>
        /// Reforge Ids dictionary. Key is reforgeId, and value is an array with first item being reforge stat and second item being reforged to stat
        /// </summary>
        private static readonly Dictionary<int, ItemStatType[]> _reforgeIds = InitializeReforgeIds();

        /// <summary>
        /// Initialize reforge ids dictionary
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, ItemStatType[]> InitializeReforgeIds()
        {
            var reforgeIds = new Dictionary<int, ItemStatType[]>();
            var statTypes = new ItemStatType[] { 
                ItemStatType.Spirit, 
                ItemStatType.DodgeRating, 
                ItemStatType.ParryRating,
                ItemStatType.HitRating,
                ItemStatType.CritRating,
                ItemStatType.HasteRating,
                ItemStatType.ExpertiseRating,
                ItemStatType.MasteryRating
            };
            var startReforgeId = 113;
            for (int i = 0; i < statTypes.Length; i++)
            {
                for (int j = 0; j < statTypes.Length; j++)
                {
                    if (i != j)
                    {
                        reforgeIds.Add(startReforgeId++, new ItemStatType[] { statTypes[i], statTypes[j] });
                    }
                }
            }
            return reforgeIds;
        }

        /// <summary>
        /// Whether the item has a blacksmithing socket added
        /// </summary>
        [JsonProperty(PropertyName="extraSocket")]
        public bool ExtraSocket
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of the enchant
        /// </summary>
        [JsonProperty(PropertyName="enchant")]
        public int? Enchant
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of the first gem
        /// </summary>
        [JsonProperty(PropertyName="gem0")]
        public int? Gem0
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of the second gem
        /// </summary>
        [JsonProperty(PropertyName="gem1")]
        public int? Gem1
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of the third gem
        /// </summary>
        [JsonProperty(PropertyName="gem2")]
        public int? Gem2
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of the fourth gem
        /// </summary>
        [JsonProperty(PropertyName="gem3")]
        public int? Gem3
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the items equipped from the same set.
        /// </summary>
        [JsonProperty(PropertyName="set")]
        public IList<int> SetItems
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of the tinker
        /// </summary>
        [JsonProperty(PropertyName="tinker")]
        public int? Tinker
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the id of reforge
        /// </summary>
        [JsonProperty(PropertyName="reforge")]
        public int? Reforge
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the item to which this item is transmogrified to look like
        /// </summary>
        [JsonProperty(PropertyName="transmogItem")]
        public int? TransmogrifyItemId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the current equipped item upgrade
        /// </summary>
        [JsonProperty(PropertyName="upgrade")]
        public EquippedItemUpgrade Upgrade
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the reforged from stat
        /// </summary>
        public ItemStatType? ReforgedFromStat
        {
            get
            {
                if (!Reforge.HasValue)
                    return null;
                return _reforgeIds[Reforge.Value][0];
            }
        }

        /// <summary>
        /// Gets the reforged to stat
        /// </summary>
        public ItemStatType? ReforgedToStat
        {
            get
            {
                if (!Reforge.HasValue)
                    return null;
                return _reforgeIds[Reforge.Value][1];
            }
        }
    }
}