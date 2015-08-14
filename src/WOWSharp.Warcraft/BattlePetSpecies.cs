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
using Newtonsoft.Json;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   information about a battle pet species
    /// </summary>
    [BattleNetCachePolicy(CacheDurationSeconds = 3600, UseSlidingExpiration = true, ShouldCheckIfCachedEntriesAreModified = true)]
    [JsonObject(MemberSerialization.OptIn)]
    public class BattlePetSpecies : ApiResponse
    {
        /// <summary>
        ///   Pet species abilities
        /// </summary>
        [JsonProperty(PropertyName="abilities")]
        public IList<BattlePetAbility> Abilities
        {
            get;
            set;
        }

        /// <summary>
        ///   whether the species can battle
        /// </summary>
        [JsonProperty(PropertyName="canBattle")]
        public bool CanBattle
        {
            get;
            set;
        }

        /// <summary>
        ///   whether creature id for the species
        /// </summary>
        [JsonProperty(PropertyName="creatureId")]
        public int CreatureId
        {
            get;
            set;
        }

        /// <summary>
        ///   description
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   description
        /// </summary>
        [JsonProperty(PropertyName="description")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the pet's icon
        /// </summary>
        [JsonProperty(PropertyName="icon")]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the pet type id
        /// </summary>
        [JsonProperty(PropertyName="petTypeId")]
        public int PetTypeId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the pet's source
        /// </summary>
        [JsonProperty(PropertyName="source")]
        public string Source
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the pet's species id
        /// </summary>
        [JsonProperty(PropertyName="speciesId")]
        public int SpeciesId
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
            return Description;
        }
    }
}