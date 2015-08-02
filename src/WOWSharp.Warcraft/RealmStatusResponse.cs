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

using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   The API response for Realm status
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [BattleNetCachePolicy(CacheDurationSeconds = 600, UseSlidingExpiration = true, ShouldCheckIfCachedEntriesAreModified = false)]
    public class RealmStatusResponse : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the realm s returned from the realm status request
        /// </summary>
        [JsonProperty(PropertyName = "realms", Required = Required.Always)]
        public IList<Realm> Realms
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Realm Count = {0}", Realms == null ? 0 : Realms.Count);
        }
    }
}