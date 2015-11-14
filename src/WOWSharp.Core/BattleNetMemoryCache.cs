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

#if LOGGING
using System;
using System.Threading.Tasks;
using Microsoft.Framework.Caching.Memory;
using Microsoft.Framework.Internal;
using WOWSharp.Interfaces;

namespace WOWSharp.Core
{
    public class BattleNetMemoryCache : IBattleNetCache
    {
        private readonly IMemoryCache _memoryCache;

        public BattleNetMemoryCache(IMemoryCache memoryCache)
        {
            if (memoryCache == null) throw new ArgumentNullException(nameof(memoryCache));
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