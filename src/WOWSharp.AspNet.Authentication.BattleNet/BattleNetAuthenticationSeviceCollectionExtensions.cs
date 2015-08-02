using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;
using WOWSharp.AspNet.Authentication.BattleNet;
using WOWSharp.Interfaces;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Extension methods for using <see cref="BattleNetAuthenticationMiddleware"/>.
    /// </summary>
    public static class BattleNetServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="DefaultRegionSelector"/> to the service collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection TryAddDefaultServices(this IServiceCollection services)
        {
            var descriptor = new ServiceDescriptor(typeof(IRegionSelector), DefaultRegionSelector.DefaultInstance);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(IBattleNetAccessTokenAccessor), typeof(BattleNetAccessTokenAccessor), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);
            return services;
        }

        

        /// <summary>
        /// configures battle.net authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureBattleNetAuthentication([NotNull] this IServiceCollection services, Action<BattleNetAuthenticationOptions> configure)
        {
            return services.ConfigureBattleNetAuthentication(configure, optionsName: "");
        }

        /// <summary>
        /// configures battle.net authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure"></param>
        /// <param name="optionsName"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureBattleNetAuthentication([NotNull] this IServiceCollection services, Action<BattleNetAuthenticationOptions> configure, string optionsName)
        {
            return services.TryAddDefaultServices().Configure(configure, optionsName);
        }

        /// <summary>
        /// configures battle.net authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureBattleNetAuthentication([NotNull] this IServiceCollection services, IConfiguration config)
        {
            return services.ConfigureBattleNetAuthentication(config, optionsName: "");
        }

        /// <summary>
        /// configures battle.net authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <param name="optionsName"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureBattleNetAuthentication([NotNull] this IServiceCollection services, IConfiguration config, string optionsName)
        {
            return services.TryAddDefaultServices().Configure<BattleNetAuthenticationOptions>(config, optionsName);
        }
    }
}
