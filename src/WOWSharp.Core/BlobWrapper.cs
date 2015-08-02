using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Core
{
    /// <summary>
    /// Wraps blobs to have last modified and path saved in cache
    /// </summary>
    public class BlobWrapper : ApiResponse
    {
        /// <summary>
        /// Content
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; set; }
    }
}
