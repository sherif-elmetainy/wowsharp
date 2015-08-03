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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WOWSharp.Core.Serialization;

namespace WOWSharp.Core
{
    /// <summary>
    ///   Base class for objects returned by battle.net community API
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApiResponse
    {
        /// <summary>
        ///   Last Modified Date
        /// </summary>
        [JsonProperty(PropertyName = "lastModified")]
        [JsonConverter(typeof(DatetimeMillisecondsConverter))]
        public DateTimeOffset LastModified
        {
            get;
            set;
        }

        /// <summary>
        ///   The path used to fetch the object
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the API call (quota information, etc)
        /// </summary>
        public ApiResponseInformation Information { get; set; }
    }
}
