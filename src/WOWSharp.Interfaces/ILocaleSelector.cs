using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Interfaces
{
    /// <summary>
    /// A service that selects the local for bnet api requests
    /// </summary>
    public interface ILocaleSelector
    {
        /// <summary>
        /// Get the locale to use for calling battle.NET API using a region 
        /// </summary>
        /// <param name="region">battle.net region</param>
        /// <returns>locale to use with that region</returns>
        string GetLocale(Region region);
    }
}
