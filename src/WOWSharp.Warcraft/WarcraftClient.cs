using Microsoft.Framework.Internal;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOWSharp.Core;
using WOWSharp.Core.Serialization;

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

        #region BattleGroups

        /// <summary>
        ///   Get the battle string to use in the Url for guild and character requests
        /// </summary>
        /// <param name="battleGroupName"> Battle Groups </param>
        /// <returns> battle string to use in Url for arena ladder </returns>
        public static string GetBattleGroupSlug(string battleGroupName)
        {
            return GetSlug(battleGroupName);
        }

        /// <summary>
        ///   Get the battlegroups for the region
        /// </summary>
        /// <returns> The status of the async operation </returns>
        public Task<BattleGroupsResponse> GetBattleGroupsAsync()
        {
            return _client.GetAsync<BattleGroupsResponse>("wow/data/battlegroups/index");
        }

        #endregion

        #region Character

        /// <summary>
        ///   Get character profile information asynchronously
        /// </summary>
        /// <param name="realm"> realm name </param>
        /// <param name="characterName"> character name </param>
        /// <param name="fieldsToRetrieve"> the profile fields to retrieve </param>
        /// <param name="callback"> Async callback </param>
        /// <param name="asyncState"> The user defined state </param>
        /// <returns> The status of the async operation </returns>
        public Task<Character> GetCharacterAsync(string realm, string characterName, CharacterFields fieldsToRetrieve)
        {
            string[] fields =
                EnumHelper<CharacterFields>.GetNames().Where(
                    name =>
                    name != "All" &&
                    (fieldsToRetrieve & (CharacterFields)Enum.Parse(typeof(CharacterFields), name, true)) != 0).Select
                    (name => char.ToLowerInvariant(name[0]) + name.Substring(1)).ToArray();
            string queryString = fields.Length == 0 ? "" : "?fields=" + string.Join(",", fields);
            return _client.GetAsync<Character>("wow/character/" + GetRealmSlug(realm) + "/" + Uri.EscapeUriString(characterName) + queryString);
        }

        #endregion Character
    }
}
