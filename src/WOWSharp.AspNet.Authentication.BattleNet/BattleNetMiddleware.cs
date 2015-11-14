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

using System;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using WOWSharp.Interfaces;

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using Blizzard Entertainment's battle.net OAuth services.
    /// </summary>
    public class BattleNetMiddleware : OAuthMiddleware<BattleNetOptions>
    {
        /// <summary>
        /// Initializes a new <see cref="BattleNetMiddleware" />
        /// </summary>
        /// <param name="next">The next middleware in the HTTP pipeline to invoke.</param>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
        /// <param name="options">Configuration options for the middleware.</param>
        /// <param name="regionSelector">Region selection service</param>
        public BattleNetMiddleware(
            RequestDelegate next,
            IDataProtectionProvider dataProtectionProvider,
            ILoggerFactory loggerFactory,
            IUrlEncoder encoder,
            IOptions<SharedAuthenticationOptions> sharedOptions,
            BattleNetOptions options,
            IRegionSelector regionSelector = null)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            if (dataProtectionProvider == null) throw new ArgumentNullException(nameof(dataProtectionProvider));
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));
            if (encoder == null) throw new ArgumentNullException(nameof(encoder));
            if (sharedOptions == null) throw new ArgumentNullException(nameof(sharedOptions));
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("wow.profile");
                Options.Scope.Add("sc2.profile");
            }
            Options.RegionSelector = regionSelector;
        }

        /// <summary>
        /// Provides the <see cref="AuthenticationHandler{BattleNetOptions}"/> object for processing authentication-related requests.
        /// </summary>
        /// <returns>An <see cref="AuthenticationHandler{BattleNetOptions}"/> configured with the <see cref="OAuthOptions"/> supplied to the constructor.</returns>
        protected override AuthenticationHandler<BattleNetOptions> CreateHandler()
        {
            return new BattleNetHandler(Backchannel, Options.RegionSelector);
        }
    }
}
