﻿// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// PvP leader board type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum PvpBracket
    {
        /// <summary>
        ///  None
        /// </summary>
        [EnumMember(Value = "none")]
        None = 0,

        /// <summary>
        ///  Arena 2v2 bracker
        /// </summary>
        [EnumMember(Value = "2v2")]
        Arena2v2,

        /// <summary>
        /// Arena 3v3 bracket
        /// </summary>
        [EnumMember(Value = "3v3")]
        Arena3v3,

        /// <summary>
        /// Arena 5v5 bracket
        /// </summary>
        [EnumMember(Value = "5v5")]
        Arena5v5,

        /// <summary>
        /// Rated battle grounds
        /// </summary>
        [EnumMember(Value = "rbg")]
        RatedBattleground
    }
}
