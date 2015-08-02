using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Interfaces
{
    /// <summary>
    /// Battle.net cache policy options
    /// </summary>
    public class BattleNetCacheOptions
    {
        /// <summary>
        /// Gets or sets whether the battle.net client will send a request to the server with IfModifiedSince header in case an entry was already found in cache
        /// </summary>
        public bool ShouldCheckIfCachedEntriesAreModified { get; set; }

        /// <summary>
        /// Gets or sets the duration of cache in seconds
        /// </summary>
        public int CacheDurationSeconds { get; set; }

        /// <summary>
        /// Whether to use sliding expiration for cache
        /// </summary>
        public bool UseSlidingExpiration { get; set; }

        /// <summary>
        /// Default <see cref="BattleNetCacheOptions"/>
        /// </summary>
        public static BattleNetCacheOptions Default { get; } = new BattleNetCacheOptions() { CacheDurationSeconds = 900, ShouldCheckIfCachedEntriesAreModified = true };
    }
}
