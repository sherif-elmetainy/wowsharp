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

#if !DOTNET
using Microsoft.Framework.DependencyInjection.Extensions;
using Microsoft.Framework.Internal;
using WOWSharp.BattleNet.Authenticator;

// ReSharper disable once CheckNamespace
namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class BNetAuthenticatorServiceCollectionExtensions
    {
        /// <summary>
        /// Adds default services to the service collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection TryAddDefaultServices([NotNull] this IServiceCollection services)
        {
            services.AddLogging();
            services.AddDataProtection();

            var descriptor = new ServiceDescriptor(typeof(IAuthenticatorDataRepository), typeof(UserProfileAuthenticatorDataRepository), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(IEnrollmentClient), typeof(EnrollmentClient), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);

            descriptor = new ServiceDescriptor(typeof(IAuthenticator), typeof(Authenticator), ServiceLifetime.Scoped);
            services.TryAdd(descriptor);

            return services;
        }

        public static IServiceCollection AddBattleNetAuthenticator([NotNull] this IServiceCollection services)
        {
            return services.TryAddDefaultServices();
        }
    }
}
#endif