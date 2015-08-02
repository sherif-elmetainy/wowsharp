using Microsoft.AspNet.Authentication;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.Logging;
using Microsoft.Framework.WebEncoders;
using Microsoft.AspNet.DataProtection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.Framework.Internal;
using WOWSharp.Interfaces;

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using Blizzard Entertainment's battle.net OAuth services.
    /// </summary>
    public class BattleNetAuthenticationMiddleware : OAuthAuthenticationMiddleware<BattleNetAuthenticationOptions>
    {
        /// <summary>
        /// Initializes a new <see cref="BattleNetAuthenticationMiddleware" />
        /// </summary>
        /// <param name="next">The next middleware in the HTTP pipeline to invoke.</param>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="externalOptions"></param>
        /// <param name="options">Configuration options for the middleware.</param>
        /// <param name="regionSelector">Region selection service</param>
        /// <param name="configureOptions"></param>
        public BattleNetAuthenticationMiddleware(
            [NotNull] RequestDelegate next,
            [NotNull] IDataProtectionProvider dataProtectionProvider,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IUrlEncoder encoder,
            [NotNull] IOptions<ExternalAuthenticationOptions> externalOptions,
            [NotNull] IOptions<BattleNetAuthenticationOptions> options,
            IRegionSelector regionSelector = null,
            ConfigureOptions<BattleNetAuthenticationOptions> configureOptions = null)
            : base(next, dataProtectionProvider, loggerFactory, encoder, externalOptions, options, configureOptions)
        {
            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("wow.profile");
                Options.Scope.Add("sc2.profile");
            }
            Options.RegionSelector = regionSelector;
        }

        /// <summary>
        /// Provides the <see cref="AuthenticationHandler"/> object for processing authentication-related requests.
        /// </summary>
        /// <returns>An <see cref="AuthenticationHandler"/> configured with the <see cref="OAuthAuthenticationOptions"/> supplied to the constructor.</returns>
        protected override AuthenticationHandler<BattleNetAuthenticationOptions> CreateHandler()
        {
            return new BattleNetAuthenticationHandler(Backchannel, Options.RegionSelector);
        }
    }
}
