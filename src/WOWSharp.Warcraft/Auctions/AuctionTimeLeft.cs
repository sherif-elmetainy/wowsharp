using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// Auction time left
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum AuctionTimeLeft
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,
        /// <summary>
        /// Short
        /// </summary>
        [EnumMember(Value = "SHORT")]
        Short = 1,

        /// <summary>
        /// Medium
        /// </summary>
        [EnumMember(Value = "MEDIUM")]
        Medium = 2,

        /// <summary>
        /// Long
        /// </summary>
        [EnumMember(Value = "LONG")]
        Long = 3,
        /// <summary>
        /// Very long
        /// </summary>
        [EnumMember(Value = "VERY_LONG")]
        VeryLong = 4
    }
}
