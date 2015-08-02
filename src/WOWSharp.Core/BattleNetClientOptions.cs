using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOWSharp.Core
{
    /// <summary>
    /// BattleNet client options
    /// </summary>
    public class BattleNetClientOptions
    {
        /// <summary>
        /// Gets or sets the battle.net API key provided by Blizzard (go to https://dev.battle.net to register and obtain an API key)
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets whether to process and parse API response information (containing information about api request quotas)
        /// </summary>
        public bool ParseApiResponseInformation { get; set; }

        /// <summary>
        /// Gets or sets whether Json serialization should fail if battle.net api replies with json payload containing a property that API doesn't understand.
        /// </summary>
        /// <remarks>Typically this should only be used in testing and development of the API to be able to catch new changes by blizzard</remarks>
        public bool ThrowErrorOnMissingMembers { get; set; }
    }
}
