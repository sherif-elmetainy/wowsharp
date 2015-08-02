using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using WOWSharp.Interfaces;
using Microsoft.Framework.Internal;

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// Reads the battle.net access token from the current http context
    /// </summary>
    public class BattleNetAccessTokenAccessor : IBattleNetAccessTokenAccessor
    {
        /// <summary>
        /// http context accessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new <see cref="BattleNetAccessTokenAccessor"/>
        /// </summary>
        /// <param name="httpContextAcessor">An <see cref="IHttpContextAccessor"/> to use with this service</param>
        public BattleNetAccessTokenAccessor([NotNull] IHttpContextAccessor httpContextAcessor )
        {
            _httpContextAccessor = httpContextAcessor;
        }

        /// <summary>
        /// Gets the value of the bnet_access_token claim
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUserAccessToken()
        {
            return _httpContextAccessor.HttpContext?.User?.Identities?.SelectMany(i => i.Claims)?.FirstOrDefault(c => c.Type == "bnet_access_token")?.Value;
        }
    }
}
