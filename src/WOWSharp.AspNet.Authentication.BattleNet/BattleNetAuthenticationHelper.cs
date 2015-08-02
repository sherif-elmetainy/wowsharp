using Microsoft.Framework.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WOWSharp.Interfaces;

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// Helper method for battle.net authentication
    /// </summary>
    internal static class BattleNetAuthenticationHelper
    {
        /// <summary>
        /// Get user's id from json payload
        /// </summary>
        /// <param name="user">json payload</param>
        /// <returns>User's id</returns>
        internal static string GetId([NotNull] this JObject user)
        {
            return user.TryGetValue("id");
        }

        /// <summary>
        /// Get user's battletag from json payload
        /// </summary>
        /// <param name="user">json payload</param>
        /// <returns>User's battletag</returns>
        internal static string GetBattleTag([NotNull] this JObject user)
        {
            return user.TryGetValue("battletag");
        }

        /// <summary>
        /// Get user's property from json payload
        /// </summary>
        /// <param name="user">json payload</param>
        /// <param name="propertyName">property name to read</param>
        /// <returns>User's property</returns>
        private static string TryGetValue(this JObject user, string propertyName)
        {
            JToken value;
            return user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }

        /// <summary>
        /// Changes the host information of a url to match that of the selected region
        /// </summary>
        /// <param name="uri">URL to change</param>
        /// <param name="region">Region to get host information from. If null uri is not changed.</param>
        /// <returns>Modified URI</returns>
        internal static Uri ChangeUriRegion([NotNull] this Uri uri, Region region)
        {
            if (region != null)
            {
                string host;
                var path = uri.PathAndQuery;
                if (path.StartsWith(BattleNetAuthenticationDefaults.UserInformationEndpoint, StringComparison.OrdinalIgnoreCase))
                {
                    host = region.ApiHost;
                }
                else
                {
                    host = region.OAuthHost;
                }
                var baseUri = new Uri("https://" + host);
                uri = new Uri(baseUri, path);
            }
            return uri;
        }

        /// <summary>
        /// Changes the host information of a url to match that of the selected region
        /// </summary>
        /// <param name="uri">URL to change</param>
        /// <param name="region">Region to get host information from. If null uri is not changed.</param>
        /// <returns>Modified URI</returns>
        internal static string ChangeUriRegion([NotNull] this string url, Region region)
        {
            if (region != null)
            {
                var uri = new Uri(url).ChangeUriRegion(region);
                return uri.ToString();
            }
            return url;
        }
    }
}
