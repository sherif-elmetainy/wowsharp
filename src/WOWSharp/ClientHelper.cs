#if DI
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.OptionsModel;
#endif

using WOWSharp.Core;
using WOWSharp.Warcraft;
using System;
#if LOGGING
using Microsoft.Framework.Logging;
#endif

namespace WOWSharp
{
    public static class ClientHelper
    {
#if !DI
        public static WarcraftClient CreateWarcraftClient(string apiKey)
        {
            var options = new BattleNetClientOptions()
            {
                ApiKey = apiKey
            };
            var client = new BattleNetClient(options);
            return new WarcraftClient(client);
        }
#endif
    }
}
