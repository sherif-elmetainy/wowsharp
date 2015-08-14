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
using Newtonsoft.Json.Converters;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents a realm
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Realm
    {
        /// <summary>
        ///   Gets or sets the realm's battle group name
        /// </summary>
        [JsonProperty(PropertyName="battlegroup")]
        public string BattleGroupName
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the realm's locale
        /// </summary>
        [JsonProperty(PropertyName="locale")]
        public string Locale
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the realm name
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the realm's population
        /// </summary>
        [JsonProperty(PropertyName="population")]
        public RealmPopulation Population
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets whether the realm is currently experiencing queues
        /// </summary>
        [JsonProperty(PropertyName = "queue")]
        public bool Queue
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the realm id used in urls and query strings
        /// </summary>
        [JsonProperty(PropertyName = "slug", Required = Required.Always)]
        public string Slug
        {
            get;
            set;
        }


        /// <summary>
        ///   Gets or sets whether the realm is up
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public bool Status
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the realms timezone
        /// </summary>
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZone
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the realm type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RealmTypes RealmType
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the status of the PVP Zone Tol Barad
        /// </summary>
        [JsonProperty(PropertyName="tol-barad")]
        public PvpZone TolBarad
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the status of the PVP zone wintergrasp
        /// </summary>
        [JsonProperty(PropertyName="wintergrasp")]
        public PvpZone WinterGrasp
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets whether the realm is PVP enabled
        /// </summary>
        public bool IsPvp => (RealmType & RealmTypes.Pvp) != 0;

        /// <summary>
        ///   Gets whether the realm has Role Play rule
        /// </summary>
        public bool IsRP => (RealmType & RealmTypes.RP) != 0;

        [JsonProperty(PropertyName = "connected_realms")]
        public IList<string> ConnectedRealms { get; set; }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Realm = {0}, Type= {1}, Status = {2}", Name,
                                 RealmType, Status);
        }
    }
}