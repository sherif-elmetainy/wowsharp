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
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WOWSharp.Interfaces;
using System.Threading;
using Microsoft.Framework.Internal;

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// Configuration options for <see cref="BattleNetAuthenticationMiddleware"/>.
    /// </summary>
    public class BattleNetAuthenticationOptions : OAuthAuthenticationOptions
    {
        /// <summary>
        /// Initializes a new <see cref="BattleNetAuthenticationOptions"/>
        /// </summary>
        public BattleNetAuthenticationOptions()
        {
            var region = Region.Default;
            AuthenticationScheme = BattleNetAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = new PathString("/signin-battlenet");
            SaveTokensAsClaims = false;

            AuthorizationEndpoint = new Uri(new Uri("https://" + region.OAuthHost), BattleNetAuthenticationDefaults.AuthorizationEndpoint).ToString();
            TokenEndpoint = new Uri(new Uri("https://" + region.OAuthHost), BattleNetAuthenticationDefaults.TokenEndpoint).ToString();
            UserInformationEndpoint = new Uri(new Uri("https://" + region.ApiHost), BattleNetAuthenticationDefaults.UserInformationEndpoint).ToString();
            BackchannelHttpHandler = new BattleNetAuthenticationMessageHandler(this);
        }

        /// <summary>
        /// Region selector service
        /// </summary>
        public IRegionSelector RegionSelector { get; set; }

        /// <summary>
        /// Http client message handler used to change host portion of request URLs to match the region selected by <see cref="RegionSelector"/> service
        /// </summary>
#if DNX451
        private class BattleNetAuthenticationMessageHandler : WebRequestHandler
#else
        private class BattleNetAuthenticationMessageHandler : WinHttpHandler
#endif
        {
            /// <summary>
            /// Reference to <see cref="BattleNetAuthenticationOptions"/> using this Handler
            /// </summary>
            private readonly BattleNetAuthenticationOptions _options;

            /// <summary>
            /// Initializes a new <see cref="BattleNetAuthenticationMessageHandler"/>
            /// </summary>
            /// <param name="options"></param>
            public BattleNetAuthenticationMessageHandler([NotNull] BattleNetAuthenticationOptions options)
            {
                _options = options;
            }

            /// <summary>
            /// Overriden to change the host part of the Request URI for HTTP requests
            /// </summary>
            /// <param name="request">Http request to modify</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>HttpResponse message</returns>
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var regionSelector = _options.RegionSelector;
                if (regionSelector != null)
                {
                    request.RequestUri = request.RequestUri.ChangeUriRegion(regionSelector.GetDefaultRegion());
                }
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}

