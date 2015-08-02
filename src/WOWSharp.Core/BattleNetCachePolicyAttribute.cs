using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BattleNetCachePolicyAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the duration of cache in seconds
        /// </summary>
        public int CacheDurationSeconds { get; set; }

        /// <summary>
        /// Whether to use sliding expiration for cache
        /// </summary>
        public bool UseSlidingExpiration { get; set; }

        /// <summary>
        /// Gets or sets whether the battle.net client will send a request to the server with IfModifiedSince header in case an entry was already found in cache
        /// </summary>
        public bool ShouldCheckIfCachedEntriesAreModified { get; set; }

    }
}
