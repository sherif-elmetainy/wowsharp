using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Core
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApiError : ApiResponse
    {
        /// <summary>
        /// Error reason
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Error status
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
