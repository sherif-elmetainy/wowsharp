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
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   information about a battle pet ability
    /// </summary>
    [BattleNetCachePolicy(CacheDurationSeconds = 3600, UseSlidingExpiration = true, ShouldCheckIfCachedEntriesAreModified = true)]
    [JsonObject(MemberSerialization.OptIn)]
    public class BattlePetAbility : ApiResponse
    {
        /// <summary>
        ///   Ability cooldown in seconds
        /// </summary>
        [JsonProperty(PropertyName="cooldown")]
        public int Cooldown
        {
            get;
            set;
        }

        /// <summary>
        ///   Ability icon image
        /// </summary>
        [JsonProperty(PropertyName="icon")]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   Ability Id
        /// </summary>
        [JsonProperty(PropertyName="id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   whether the ability is passive
        /// </summary>
        [JsonProperty(PropertyName="isPassive")]
        public bool IsPassive
        {
            get;
            set;
        }

        /// <summary>
        ///   Ability name
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Id of the pet that can perform this ability
        /// </summary>
        [JsonProperty(PropertyName="petTypeId")]
        public int PetTypeId
        {
            get;
            set;
        }

        /// <summary>
        ///   Ability rounds
        /// </summary>
        [JsonProperty(PropertyName="rounds")]
        public int Rounds
        {
            get;
            set;
        }

        /// <summary>
        ///   whether to show hints for ability
        /// </summary>
        [JsonProperty(PropertyName="showHints")]
        public bool ShowHints
        {
            get;
            set;
        }

        /// <summary>
        ///   Ability cooldown in seconds
        /// </summary>
        [JsonProperty(PropertyName="order")]
        public int Order
        {
            get;
            set;
        }

        /// <summary>
        ///   Ability required level
        /// </summary>
        [JsonProperty(PropertyName="requiredLevel")]
        public int RequiredLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Ability slot
        /// </summary>
        [JsonProperty(PropertyName="slot")]
        public int Slot
        {
            get;
            set;
        }

        /// <summary>
        /// Whether to show or hide hints
        /// </summary>
        [JsonProperty(PropertyName="hideHints")]
        public bool HideHints
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