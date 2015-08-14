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

using System.Linq;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Internal;
using WOWSharp.Interfaces;

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
            return _httpContextAccessor.HttpContext?.User?.Identities?.SelectMany(i => i.Claims).FirstOrDefault(c => c.Type == "bnet_access_token")?.Value;
        }
    }
}
