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

#if DI
using System.Net.Http;
using Microsoft.Framework.Internal;
using WOWSharp.Core;
using WOWSharp.Interfaces;
using WOWSharp.Warcraft;
using Microsoft.Framework.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
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
        private static void TryAddDefaultServices([NotNull] this IServiceCollection services)
        {
            services.AddLogging();
            services.AddOptions();

            var descriptor = new ServiceDescriptor(typeof(IRegionSelector), DefaultRegionSelector.DefaultInstance);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(IBattleNetClient), typeof(BattleNetClient), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(HttpClient), typeof(HttpClient), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);
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

            descriptor = new ServiceDescriptor(typeof(IBattleNetCachePolicy), typeof(AttributesBattleNetCachePolicy), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);
            return services;
        }
    }
}
#endif