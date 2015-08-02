#if LOGGING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Caching.Memory;
using WOWSharp.Interfaces;
using Microsoft.Framework.Internal;

namespace WOWSharp.Core
{
    public class BattleNetMemoryCache : IBattleNetCache
    {
        private readonly IMemoryCache _memoryCache;

        public BattleNetMemoryCache([NotNull] IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<object> GetAsync(string key)
        {
            return Task.FromResult(_memoryCache.Get(key));
        }

        public Task SetAsync(string key, object value, BattleNetCacheOptions options)
        {
            var time = new TimeSpan(0, 0, options?.CacheDurationSeconds ?? 3600);
            _memoryCache.Set(key, value, new MemoryCacheEntryOptions()
            {
                SlidingExpiration = options?.UseSlidingExpiration?? false ? time : default(TimeSpan?),
                AbsoluteExpirationRelativeToNow = options?.UseSlidingExpiration ?? false ? time : default(TimeSpan?),
                Priority = CacheItemPriority.Normal,
            });
            return Task.FromResult<object>(null);
        }
    }
}
#endif