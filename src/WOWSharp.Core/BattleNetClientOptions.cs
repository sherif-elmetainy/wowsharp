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
