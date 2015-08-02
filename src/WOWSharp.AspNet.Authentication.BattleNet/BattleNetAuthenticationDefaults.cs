namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// Battle.Net OAUTH authentication default settings
    /// </summary>
    public static class BattleNetAuthenticationDefaults
    {
        /// <summary>
        /// Default authentication scheme
        /// </summary>
        public const string AuthenticationScheme = "BattleNet";

        /// <summary>
        /// Absolute URL (without protocol and Host information) of authorization (challenge) endpoint
        /// </summary>
        public const string AuthorizationEndpoint = "/oauth/authorize";

        /// <summary>
        /// Absolute URL (without protocol and Host information) of token endpoint
        /// </summary>
        public const string TokenEndpoint = "/oauth/token";

        /// <summary>
        /// Absolute URL (without protocol and Host information) of use information endpoint
        /// </summary>
        public const string UserInformationEndpoint = "/account/user";
    }
}
