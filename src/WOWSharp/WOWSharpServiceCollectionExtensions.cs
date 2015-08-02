#if DI
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.DependencyInjection;
using WOWSharp.Interfaces;
using WOWSharp.Core;
using WOWSharp.Warcraft;
using System.Net.Http;
using Microsoft.Framework.Internal;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class WOWSharpServiceCollectionExtensions
    {
        /// <summary>
        /// Adds default services to the service collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection TryAddDefaultServices([NotNull] this IServiceCollection services)
        {
            services.AddLogging();
            services.AddOptions();

            var descriptor = new ServiceDescriptor(typeof(IRegionSelector), DefaultRegionSelector.DefaultInstance);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(IBattleNetClient), typeof(BattleNetClient), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(HttpClient), typeof(HttpClient), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);

            return services;
        }

        /// <summary>
        /// Adds warcraft services to the collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWarcraft([NotNull] this IServiceCollection services)
        {
            services.TryAddDefaultServices();
            var descriptor = new ServiceDescriptor(typeof(WarcraftClient), typeof(WarcraftClient), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);
            return services;
        }

        /// <summary>
        /// Adds warcraft services to the collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBattleNetCache([NotNull] this IServiceCollection services)
        {
            services.AddCaching();
            services.TryAddDefaultServices();
            var descriptor = new ServiceDescriptor(typeof(IBattleNetCache), typeof(BattleNetMemoryCache), ServiceLifetime.Singleton);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(IBattleNetCachePolicy), typeof(DataAnnotationsBattleNetCachePolicy), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);
            return services;
        }
    }
}
#endif