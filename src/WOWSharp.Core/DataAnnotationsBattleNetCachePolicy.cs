using Microsoft.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WOWSharp.Interfaces;
using System.Reflection;

namespace WOWSharp.Core
{
    public class DataAnnotationsBattleNetCachePolicy : IBattleNetCachePolicy
    {
        public BattleNetCacheOptions GetBattleNetCacheOptions([NotNull] object obj)
        {
            var type = obj.GetType();
#if DOTNET
            var attrs = type.GetTypeInfo().GetCustomAttributes(typeof(BattleNetCachePolicyAttribute), true);
#else
            var attrs = type.GetCustomAttributes(typeof(BattleNetCachePolicyAttribute), true);
#endif
            var attr = attrs?.Cast<BattleNetCachePolicyAttribute>().FirstOrDefault();
            if (attr == null)
                return BattleNetCacheOptions.Default;
            return new BattleNetCacheOptions()
            {
                CacheDurationSeconds = attr.CacheDurationSeconds,
                ShouldCheckIfCachedEntriesAreModified = attr.ShouldCheckIfCachedEntriesAreModified,
                UseSlidingExpiration = attr.UseSlidingExpiration
            };
        }
    }
}
