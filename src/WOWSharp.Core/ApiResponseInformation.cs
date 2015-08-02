using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Core
{
    public class ApiResponseInformation
    {
        /// <summary>
        /// Value of the X-Mashery-Responder header in the response
        /// </summary>
        public string MasheryResponder { get; set; }

        /// <summary>
        /// Quota requests per second alloted  (returned by X-Plan-Qps-Allotted header)
        /// </summary>
        public int PlanQpsAlloted { get; set; }

        /// <summary>
        /// Quota requests per second used (returned by X-Plan-Qps-Current header)
        /// </summary>
        public int PlanQpsCurrent { get; set; }

        /// <summary>
        /// Quota alloted  (returned by X-Quota-Allotted header)
        /// </summary>
        public int PlanQuotaAlloted { get; set; }

        /// <summary>
        /// Quota used (returned by X-Quota-Current header)
        /// </summary>
        public int PlanQuotaCurrent { get; set; }

        /// <summary>
        /// Plan Quota reset date/time (returned by X-Quota-Reset header)
        /// </summary>
        public DateTime PlanQuotaReset { get; set; }

        /// <summary>
        /// Size of the json payload returned
        /// </summary>
        public int ContentLength { get; set; }
    }
}
