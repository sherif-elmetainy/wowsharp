using Microsoft.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    public class WarcraftClient
    {
        private readonly IBattleNetClient _client;

        public WarcraftClient([NotNull] IBattleNetClient client)
        {
            _client = client;
        }

        #region Realms

        /// <summary>
        ///   const used to replace accented characters with non-accented ones
        /// </summary>
        private const string AccentedCharacters = "ÂâÄäÃãÁáÀàÊêËëÉéÈèÎîÏïÍíÌìÔôÖöÕõÓóÒòÛûÜüÚúÙùÑñÇç";

        /// <summary>
        ///   const used to replace accented characters with non-accented ones
        /// </summary>
        private const string ReplacedCharacters = "aaaaaaaaaaeeeeeeeeiiiiiiiioooooooooouuuuuuuunncc";

        /// <summary>
        ///   Get a realm or battleground slug
        /// </summary>
        /// <param name="identifier"> string </param>
        /// <returns> slug </returns>
        private static string GetSlug(string identifier)
        {
            var builder = new StringBuilder();
            bool dash = false;
            foreach (char ch in identifier)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    dash = false;
                    // String.Normalise is not available in Portable Libraries
                    int index = AccentedCharacters.IndexOf(ch);
                    builder.Append(index >= 0 ? ReplacedCharacters[index] : char.ToLowerInvariant(ch));
                }
                else if (ch == ' ' && !dash)
                {
                    dash = true;
                    builder.Append('-');
                }
            }
            return builder.ToString();
        }

        /// <summary>
        ///   Get the realm string to use in the Url for guild and character requests
        /// </summary>
        /// <param name="realmName"> Realm name </param>
        /// <returns> realm string to use in Url for guild and character requests </returns>
        public static string GetRealmSlug(string realmName)
        {
            return GetSlug(realmName);
        }

        /// <summary>
        ///   Get the realm status for all the realms in the region asynchronously
        /// </summary>
        /// <returns> The status of the async operation </returns>
        public Task<RealmStatusResponse> GetRealmStatusAsync()
        {
            return _client.GetAsync<RealmStatusResponse>("wow/realm/status");
        }

        /// <summary>
        ///   Get the realm status for all the realms in the region asynchronously
        /// </summary>
        /// <param name="realms"> Realms to query </param>
        /// <returns> The status of the async operation </returns>
        public Task<RealmStatusResponse> GetRealmStatusAsync(string[] realms)
        {
            if (realms == null || realms.Length == 0)
                return GetRealmStatusAsync();
            string queryString = "?realms=" + string.Join(",",
                                                          realms.Where(r => !string.IsNullOrEmpty(r)).Select(
                                                              GetRealmSlug).ToArray());
            return _client.GetAsync<RealmStatusResponse>("wow/realm/status" + queryString);
        }

        #endregion
    }
}
