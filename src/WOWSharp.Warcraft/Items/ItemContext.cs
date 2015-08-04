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
using WOWSharp.Core.Serialization;

namespace WOWSharp.WarCraft
{
    /// <summary>
    /// Various versions of the same item that can drop in varius difficulties
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum ItemContext
    {
        /// <summary>
        /// No context
        /// </summary>
        [EnumMember(Value = "none")]
        None,
        /// <summary>
        /// Obtained from heroic difficulty raid
        /// </summary>
        [EnumMember(Value = "raid-heroic")]
        RaidHeroic,
        /// <summary>
        /// Obtained from normal difficulty raid
        /// </summary>
        [EnumMember(Value = "raid-normal")]
        RaidNormal,
        /// <summary>
        /// Obtained from mythic difficulty raid
        /// </summary>
        [EnumMember(Value = "raid-mythic")]
        RaidMythic,
        /// <summary>
        /// Obtained from raid finder difficulty raid
        /// </summary>
        [EnumMember(Value = "raid-finder")]
        RaidFinder,
        /// <summary>
        /// No idea what's that is
        /// </summary>
        [EnumMember(Value = "dungeon-level-up-1")]
        DungeonLevelUp1,
        /// <summary>
        /// No idea what's that is
        /// </summary>
        [EnumMember(Value = "dungeon-level-up-2")]
        DungeonLevelUp2,
        /// <summary>
        /// No idea what's that is
        /// </summary>
        [EnumMember(Value = "dungeon-level-up-3")]
        DungeonLevelUp3,
        /// <summary>
        /// No idea what's that is
        /// </summary>
        [EnumMember(Value = "dungeon-level-up-4")]
        DungeonLevelUp4,
        /// <summary>
        /// obtained from normal difficulty dungeon
        /// </summary>
        [EnumMember(Value = "dungeon-normal")]
        DungeonNormal,
        /// <summary>
        /// obtained from heroic difficulty dungeon
        /// </summary>
        [EnumMember(Value = "dungeon-heroic")]
        DungeonHeroic,
        /// <summary>
        /// obtained from mythic difficulty dungeon
        /// </summary>
        [EnumMember(Value = "dungeon-mythic")]
        DungeonMythic,
        /// <summary>
        /// obtained from timewalking TBC or LK dungeon
        /// </summary>
        [EnumMember(Value = "time-walker")]
        Timewalker,
        /// <summary>
        /// Crafted
        /// </summary>
        [EnumMember(Value = "trade-skill")]
        TradeSkipp
    }
}

