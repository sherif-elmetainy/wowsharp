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

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   character pet slot
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterPetSlot
    {
        /// <summary>
        ///   gets or sets ability ids
        /// </summary>
        [JsonProperty(PropertyName="abilities")]
        public IList<int> Abilities
        {
            get;
            set;
        }
        
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
        ///   gets or sets whether the slot is empty
        /// </summary>
        [JsonProperty(PropertyName="isEmpty")]
        public bool IsEmpty
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether the slot is locked
        /// </summary>
        [JsonProperty(PropertyName="isLocked")]
        public bool IsLocked
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets slot number
        /// </summary>
        [JsonProperty(PropertyName="slot")]
        public int Slot
        {
            get;
            set;
        }
    }
}