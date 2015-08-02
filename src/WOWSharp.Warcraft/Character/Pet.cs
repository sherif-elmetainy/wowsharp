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

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// A battle pet
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Pet
    {
        /// <summary>
        ///   gets or sets battlePet guid
        /// </summary>
        [JsonProperty(PropertyName="battlePetGuid")]
        public string BattlePetGuid
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether the pet can battle
        /// </summary>
        [JsonProperty(PropertyName="canBattle")]
        public bool CanBattle
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets creature id
        /// </summary>
        [JsonProperty(PropertyName="creatureId")]
        public int CreatureId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets creature name
        /// </summary>
        [JsonProperty(PropertyName="creatureName")]
        public string CreatureName
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets icon
        /// </summary>
        [JsonProperty(PropertyName="icon")]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether this pet is player's favourite
        /// </summary>
        [JsonProperty(PropertyName="isFavorite")]
        public bool IsFavorite
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets item id
        /// </summary>
        [JsonProperty(PropertyName="itemId")]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets pet's name
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets quality of the pet
        /// </summary>
        [JsonProperty(PropertyName="qualityId")]
        public ItemQuality Quality
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets spell id
        /// </summary>
        [JsonProperty(PropertyName="spellId")]
        public int SpellId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets pet's status
        /// </summary>
        [JsonProperty(PropertyName="stats")]
        public PetStats Stats
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether first ability slot is selected
        /// </summary>
        [JsonProperty(PropertyName="isFirstAbilitySlotSelected")]
        public bool IsFirstAbilitySlotSelected
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether second ability slot is selected
        /// </summary>
        [JsonProperty(PropertyName="isSecondAbilitySlotSelected")]
        public bool IsSecondAbilitySlotSelected
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether first ability slot is selected
        /// </summary>
        [JsonProperty(PropertyName="isThirdAbilitySlotSelected")]
        public bool IsThirdAbilitySlotSelected
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
            return Name;
        }
    }
}