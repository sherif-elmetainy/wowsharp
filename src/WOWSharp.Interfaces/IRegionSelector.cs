using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Interfaces
{
    /// <summary>
    /// Selects the default region
    /// </summary>
    public interface IRegionSelector
    {
        /// <summary>
        /// Gets the default region
        /// </summary>
        /// <returns>Default WOW API Region</returns>
        Region GetDefaultRegion();

        /// <summary>
        /// Gets region by region name
        /// </summary>
        /// <param name="regionName">region name</param>
        /// <returns>Gets the WOW API Region by name</returns>
        Region GetRegion(string regionName);
    }
}
