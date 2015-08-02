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
