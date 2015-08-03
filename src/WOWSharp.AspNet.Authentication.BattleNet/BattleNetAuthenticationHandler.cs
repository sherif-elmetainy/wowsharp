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

using Microsoft.AspNet.Authentication.OAuth;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.WebUtilities;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using WOWSharp.Interfaces;

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// Battle.NET OAUTH authentication handler
    /// </summary>
    public class BattleNetAuthenticationHandler : OAuthAuthenticationHandler<BattleNetAuthenticationOptions>
    {
        /// <summary>
        /// A reference fo region selection service
        /// </summary>
        private readonly IRegionSelector _regionSelector;

        /// <summary>
        /// Constructor. Initializes a new instance of BattleNetAuthenticationHandler class
        /// </summary>
        /// <param name="backChannel">Httpclient used as backChannel to contact Token endpoint and user information endpoint</param>
        /// <param name="regionSelector"></param>
        public BattleNetAuthenticationHandler(HttpClient backChannel, IRegionSelector regionSelector): base(backChannel)
        {
            _regionSelector = regionSelector;
        }

        /// <summary>
        /// Get authorization endpoint (overriden to use the Region Selector service to override the host for the Url)
        /// </summary>
        /// <param name="properties">authentication properties</param>
        /// <param name="redirectUri">redirect URI</param>
        /// <returns></returns>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            // Calling base class to get user endpoint
            var url = base.BuildChallengeUrl(properties, redirectUri);
            if (_regionSelector != null)
            {
                // If we have a region selector service, use it to change the Host for the challenge URL
                var region = _regionSelector.GetDefaultRegion();
                url = url.ChangeUriRegion(region);
            }
            return url;
        }


        /// <summary>
        /// Creates an authentication ticket with battle.net information in the claims identity
        /// </summary>
        /// <param name="identity">claims identity to hold user information</param>
        /// <param name="properties">authentication properties</param>
        /// <param name="tokens">OAuth authentication tokens</param>
        /// <returns>Authentication ticket</returns>
        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            // using the backchannel, call the User information endpoint to get user's id and battletag
            var requestUri = Options.UserInformationEndpoint;
            var queryStrings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            queryStrings.Add("access_token", tokens.AccessToken);
            requestUri = QueryHelpers.AddQueryString(requestUri, queryStrings);

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await Backchannel.SendAsync(request, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            var text = await response.Content.ReadAsStringAsync();
            var payload = JObject.Parse(text);

            var context = new OAuthAuthenticatedContext(Context, Options, Backchannel, tokens, payload);

            // Add ID and battletag claims to the claims identity
            var id = payload.GetId();
            if (!string.IsNullOrEmpty(id))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var battletag = payload.GetBattleTag();
            if (!string.IsNullOrEmpty(battletag))
            {
                identity.AddClaim(new Claim("BattleTag", battletag, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim(ClaimTypes.Name, battletag, ClaimValueTypes.String, Options.ClaimsIssuer));
            }


            // Tokens are normally saved if SaveTokensAsClaims is set to true, however, we need to distinguish bnet_access_token from tokens obtained by other oauth providers
            identity.AddClaim(new Claim("bnet_access_token", tokens.AccessToken,
                                                ClaimValueTypes.String, Options.ClaimsIssuer));

            context.Properties = properties;
            context.Principal = new ClaimsPrincipal(identity);

            await Options.Notifications.Authenticated(context);
            return new AuthenticationTicket(context.Principal, context.Properties, context.Options.AuthenticationScheme);
        }
    }
}
