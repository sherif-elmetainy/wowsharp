﻿#region LICENSE
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
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Character class enumeration
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum ClassKey
    {
        /// <summary>
        ///   None
        /// </summary>
        None = 0,

        /// <summary>
        ///   Warrior
        /// </summary>
        [EnumMember(Value = "warrior")]
        Warrior = 1,

        /// <summary>
        ///   Paladin
        /// </summary>
        [EnumMember(Value = "paladin")]
        Paladin = 2,

        /// <summary>
        ///   Hunter
        /// </summary>
        [EnumMember(Value = "hunter")]
        Hunter = 3,

        /// <summary>
        ///   Rogue
        /// </summary>
        [EnumMember(Value = "rogue")]
        Rogue = 4,

        /// <summary>
        ///   Priest
        /// </summary>
        [EnumMember(Value = "priest")]
        Priest = 5,

        /// <summary>
        ///   Death Knight
        /// </summary>
        [EnumMember(Value = "death-knight")]
        DeathKnight = 6,

        /// <summary>
        ///   Shaman
        /// </summary>
        [EnumMember(Value = "shaman")]
        Shaman = 7,

        /// <summary>
        ///   Mage
        /// </summary>
        [EnumMember(Value = "mage")]
        Mage = 8,

        /// <summary>
        ///   Warlock
        /// </summary>
        [EnumMember(Value = "warlock")]
        Warlock = 9,

        /// <summary>
        ///   Monk
        /// </summary>
        [EnumMember(Value = "monk")]
        Monk = 10,

        /// <summary>
        ///   Druid
        /// </summary>
        [EnumMember(Value = "druid")]
        Druid = 11
    }
}