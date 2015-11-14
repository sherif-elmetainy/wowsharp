using System;
using System.Linq;
using WOWSharp.Interfaces;
#if DNXCORE50
using System.Reflection;
#endif

namespace WOWSharp.Core
{
    public class AttributesBattleNetCachePolicy : IBattleNetCachePolicy
    {
        public BattleNetCacheOptions GetBattleNetCacheOptions(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            var type = obj.GetType();
#if DNXCORE50
            var attrs = type.GetTypeInfo().GetCustomAttributes(typeof(BattleNetCachePolicyAttribute), true);
#else
            var attrs = type.GetCustomAttributes(typeof(BattleNetCachePolicyAttribute), true);
#endif
            var attr = attrs.Cast<BattleNetCachePolicyAttribute>().FirstOrDefault();
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
