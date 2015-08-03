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


using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Globalization;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// Represents response to the Leader board API
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [BattleNetCachePolicy(CacheDurationSeconds = 600, UseSlidingExpiration = false, ShouldCheckIfCachedEntriesAreModified = true)]
    public class PvpLeaderboardResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the leader board returned by APIs
        /// </summary>
        [JsonProperty(PropertyName="rows", Required = Required.Always)]
        public IList<PvpLeaderboardRecord> Leaderboard
        {
            get;
            set;
        }

        /// <summary>
        ///   String representation for debugging
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return (Leaderboard == null ? "0" : Leaderboard.Count.ToString(CultureInfo.InvariantCulture)) + " Records";
        }
    }
}
