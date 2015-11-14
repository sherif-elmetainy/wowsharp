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
using WOWSharp.AspNet.Authentication.BattleNet;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="BattleNetMiddleware"/>.
    /// </summary>
    public static class BattleNetAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="BattleNetMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables BattleNet authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A <see cref="BattleNetOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseBattleNetAuthentication(this IApplicationBuilder app, BattleNetOptions options)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            if (options == null) throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<BattleNetMiddleware>(options);
        }

        /// <summary>
        /// Adds the <see cref="BattleNetMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables BattleNet authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="configureOptions">An action delegate to configure the provided <see cref="BattleNetOptions"/>.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseBattleNetAuthentication(this IApplicationBuilder app, Action<BattleNetOptions> configureOptions)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            
            var options = new BattleNetOptions();
            configureOptions?.Invoke(options);
            return app.UseBattleNetAuthentication(options);
        }
    }
}