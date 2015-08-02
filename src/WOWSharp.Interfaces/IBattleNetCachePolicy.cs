using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Interfaces
{
    /// <summary>
    /// A service that gets the caching options for object
    /// </summary>
    public interface IBattleNetCachePolicy
    {
        /// <summary>
        /// Gets caching options for objects
        /// </summary>
        /// <param name="obj">object to get caching policy for</param>
        /// <returns>Caching options for object</returns>
        BattleNetCacheOptions GetBattleNetCacheOptions(object obj);

        
    }
}
