using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.DependencyInjection;
using WOWSharp.Core;
using WOWSharp.Warcraft;
using Microsoft.Framework.Configuration;
using System.Net.Http;
using WOWSharp.Interfaces;

namespace WOWSharp.Test
{
    public static class TestHelper
    {
        private static IServiceProvider CreateServiceProvider()
        {
            var builder = new ConfigurationBuilder(".").AddUserSecrets();
            var configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddLogging();
            services.AddOptions();
            services.Configure<BattleNetClientOptions>(options =>
            {
                options.ApiKey = configuration["Authentication:BattleNet:Key"];
                options.ParseApiResponseInformation = true;
                options.ThrowErrorOnMissingMembers = true;
            });
            services.AddScoped<HttpClient>();
            services.AddInstance<IRegionSelector>(DefaultRegionSelector.DefaultInstance);
            services.AddScoped<IBattleNetClient, BattleNetClient>();
            services.AddScoped<WarcraftClient>();

            return services.BuildServiceProvider();
        }

        public static WarcraftClient CreateDefaultWarcraftClient()
        {
            var serviceProvider = CreateServiceProvider();
            var client = serviceProvider.GetRequiredService<WarcraftClient>();
            return client;
        }
    }
}
