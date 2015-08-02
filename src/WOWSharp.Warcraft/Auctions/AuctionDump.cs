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
    ///   Represents a realm auctions dump
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AuctionDump : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the realm for which the dump belongs (note that realm type, status and queue are not retrieved)
        /// </summary>
        [JsonProperty(PropertyName="realm", Required = Required.Always)]
        public Realm Realm
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the alliance auction house data
        /// </summary>
        [JsonProperty(PropertyName="alliance", Required = Required.Always)]
        public AuctionHouse Alliance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the horde auction house data
        /// </summary>
        [JsonProperty(PropertyName="horde", Required = Required.Always)]
        public AuctionHouse Horde
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the neutral auction house data
        /// </summary>
        [JsonProperty(PropertyName="neutral", Required = Required.Always)]
        public AuctionHouse Neutral
        {
            get;
            set;
        }
    }
}