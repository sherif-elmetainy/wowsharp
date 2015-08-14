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

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   information about a mount
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Mount
    {
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
        ///   gets or sets icon
        /// </summary>
        [JsonProperty(PropertyName="icon")]
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether the mount is aquatic
        /// </summary>
        [JsonProperty(PropertyName="isAquatic")]
        public bool IsAquatic
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether the mount can fly
        /// </summary>
        [JsonProperty(PropertyName="isFlying")]
        public bool IsFlying
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether the mount is a ground mount
        /// </summary>
        [JsonProperty(PropertyName="isGround")]
        public bool IsGround
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets whether the mount can jump
        /// </summary>
        [JsonProperty(PropertyName="isJumping")]
        public bool IsJumping
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets item id to learn the mount
        /// </summary>
        [JsonProperty(PropertyName="itemId")]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets name of the mount
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets quality
        /// </summary>
        [JsonProperty(PropertyName="qualityId")]
        public ItemQuality Quality
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets spell id to summon the mount
        /// </summary>
        [JsonProperty(PropertyName="spellId")]
        public int SpellId
        {
            get;
            set;
        }

        /// <summary>
        ///   name of the mount (For debugging purposes)
        /// </summary>
        /// <returns> string representation </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}