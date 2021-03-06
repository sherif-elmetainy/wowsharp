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

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WOWSharp.Core;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents a guild's profile
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [BattleNetCachePolicy(CacheDurationSeconds = 600, UseSlidingExpiration = false, ShouldCheckIfCachedEntriesAreModified = true)]
    public class Guild : ApiResponse
    {
        /// <summary>
        ///   Gets or sets the guild's name
        /// </summary>
        [JsonProperty(PropertyName="name", Required = Required.Always)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the guild's battlegroup name
        /// </summary>
        [JsonProperty(PropertyName="battlegroup", Required = Required.Always)]
        public string BattleGroupName
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the guild's realm
        /// </summary>
        [JsonProperty(PropertyName="realm", Required = Required.Always)]
        public string Realm
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the guild's emblem
        /// </summary>
        [JsonProperty(PropertyName="emblem")]
        public GuildEmblem Emblem
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the guild's level
        /// </summary>
        [JsonProperty(PropertyName="level", Required = Required.Always)]
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the guild's faction
        /// </summary>
        [JsonProperty(PropertyName="side", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Faction Faction
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the guild's total achievement points
        /// </summary>
        [JsonProperty(PropertyName="achievementPoints", Required = Required.Always)]
        public int AchievementPoints
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets a list of all guild members
        /// </summary>
        [JsonProperty(PropertyName="members")]
        public IList<GuildMembership> Members
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets information about guild's achievements
        /// </summary>
        [JsonProperty(PropertyName="achievements")]
        public Achievements Achievements
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets guild news feed
        /// </summary>
        [JsonProperty(PropertyName="news")]
        public IList<GuildNewsItem> News
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets information about challenges completed by the guild
        /// </summary>
        [JsonProperty(PropertyName="challenge")]
        public IList<Challenge> Challenges
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets string representation (for debugging purposes)
        /// </summary>
        /// <returns> Gets string representation (for debugging purposes) </returns>
        public override string ToString()
        {
            return Name;
        }

        ///// <summary>
        /////   Performs additional processing after the guild information is deserialized
        ///// </summary>
        ///// <param name="client"> </param>
        //protected internal override void OnDeserialized(ApiClient client)
        //{
        //    base.OnDeserialized(client);
        //    if (Members != null)
        //    {
        //        //long lastModified = (long)(DateTimeOffset.Now - new DateTimeOffset(1970, 1, 1, 0, 0, 0, Timespan.Zero)).TotalMilliseconds;
        //        for (int i = 0; i < Members.Count; i++)
        //        {
        //            Character ch = Members[i].Character;
        //            ch.LastModified = LastModified;
        //            ch.Client = client;
        //            ch.Path = "/api/wow/character/" + WowClient.GetRealmSlug(ch.Realm) + "/" +
        //                      Uri.EscapeUriString(ch.Name);
        //            ch.OnDeserialized(client);
        //        }
        //    }
        //}
    }
}