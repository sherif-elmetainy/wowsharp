﻿#region LICENSE
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

namespace WOWSharp.AspNet.Authentication.BattleNet
{
    /// <summary>
    /// Battle.Net OAUTH authentication default settings
    /// </summary>
    public static class BattleNetDefaults
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
