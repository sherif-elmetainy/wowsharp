// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WOWSharp.Warcraft
{
    /// <summary>
    /// Information about an equipped item upgrade
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class EquippedItemUpgrade
    {
        /// <summary>
        /// Gets or sets the current number of upgrades made on the item
        /// </summary>
        [JsonProperty(PropertyName="current")]
        public int Current
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total number of upgrades possible on the item
        /// </summary>
        [JsonProperty(PropertyName="total")]
        public int Total
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item level increment of the upgraded item
        /// </summary>
        [JsonProperty(PropertyName="itemLevelIncrement")]
        public int ItemLevelIncrement
        {
            get;
            set;
        }
    }
}
