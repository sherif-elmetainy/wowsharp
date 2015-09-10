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
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection.Extensions;
using Microsoft.Framework.Internal;
using WOWSharp.AspNet.Authentication.BattleNet;
using WOWSharp.Interfaces;

// ReSharper disable once CheckNamespace
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
