using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Interfaces
{
    /// <summary>
    /// A service used to get the access token for the current user
    /// </summary>
    public interface IBattleNetAccessTokenAccessor
    {
        /// <summary>
        /// Get the OAuth access token for the current user
        /// </summary>
        /// <returns>the OAuth access token for the current user</returns>
        string GetCurrentUserAccessToken();
    }
}
