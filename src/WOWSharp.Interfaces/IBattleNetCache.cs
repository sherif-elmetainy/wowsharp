using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Interfaces
{
    /// <summary>
    ///   Represents a caching implementation that caches bnet api query results.
    /// </summary>
    public interface IBattleNetCache
    {
        /// <summary>
        ///   Returns the value associated with the given key.
        /// </summary>
        /// <param name="key"> Key of item to return from cache. </param>
        /// <returns> Value stored in cache </returns>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        Task<object> GetAsync(string key);

        /// <summary>
        ///   Adds new CacheItem to cache. If another item already exists with the same key, that item is removed before
        ///   the new item is added.
        /// </summary>
        /// <param name="key"> Identifier for this CacheItem </param>
        /// <param name="value"> Value to be stored in cache. </param>
        /// <exception cref="ArgumentNullException">Provided key is null</exception>
        /// <exception cref="ArgumentException">Provided key is an empty string</exception>
        Task SetAsync(string key, object value, BattleNetCacheOptions options);
    }
}
