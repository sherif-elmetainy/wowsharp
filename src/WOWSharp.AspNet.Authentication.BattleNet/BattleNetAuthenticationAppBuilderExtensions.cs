using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;
using WOWSharp.AspNet.Authentication.BattleNet;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="BattleNetAuthenticationMiddleware"/>.
    /// </summary>
    public static class BattleNetAuthenticationAppBuilderExtensions
    {
        /// <summary>
        /// Authenticate users using BattleNet OAuth 2.0.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> passed to the configure method.</param>
        /// <param name="configureOptions">Used to configure Middleware options.</param>
        /// <param name="optionsName">Name of the options instance to be used</param>
        /// <returns>The updated <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseBattleNetAuthentication([NotNull] this IApplicationBuilder app, Action<BattleNetAuthenticationOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<BattleNetAuthenticationMiddleware>(
                 new ConfigureOptions<BattleNetAuthenticationOptions>(configureOptions ?? (o => { }))
                 {
                     Name = optionsName
                 });
        }
    }
}