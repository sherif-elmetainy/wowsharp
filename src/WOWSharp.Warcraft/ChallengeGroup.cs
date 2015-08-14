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

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   information about a group that complete a challenge mode
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChallengeGroup
    {
        /// <summary>
        ///   gets or sets completion date
        /// </summary>
        [JsonProperty(PropertyName="date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset? Date
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets name of the faction of the group
        /// </summary>
        [JsonProperty(PropertyName="faction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Faction Faction
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets isrecurring (no idea what that means)
        /// </summary>
        [JsonProperty(PropertyName="isRecurring")]
        public bool IsRecurring
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets name of medal
        /// </summary>
        [JsonProperty(PropertyName="medal")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChallengeMedalType Medal
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets group members
        /// </summary>
        [JsonProperty(PropertyName="members")]
        public IList<ChallengeGroupMember> Members
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets rank
        /// </summary>
        [JsonProperty(PropertyName="ranking")]
        public int Ranking
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets time
        /// </summary>
        [JsonProperty(PropertyName="time")]
        public ChallengeCompletionTime Time
        {
            get;
            set;
        }

        /// <summary>
        /// The challenge mode's group guild
        /// </summary>
        [JsonProperty(PropertyName="guild")]
        public CharacterGuild Guild
        {
            get;
            set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return $"{Ranking}: {Members?.Count ?? 0} members, {Medal} - {Time}";
        }
    }
}