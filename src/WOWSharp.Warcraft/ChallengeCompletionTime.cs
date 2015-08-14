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
using Newtonsoft.Json;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Challenge mode completion time
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChallengeCompletionTime
    {
        /// <summary>
        /// Returned by Blizzard, seems to be always true. No idea what this property stands for. I don't see a way the completion time would be negative!!
        /// </summary>
        [JsonProperty(PropertyName="isPositive")]
        public bool IsPositive
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets number of hours
        /// </summary>
        [JsonProperty(PropertyName="hours")]
        public int Hours
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets number of minutes
        /// </summary>
        [JsonProperty(PropertyName="minutes")]
        public int Minutes
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets number of seconds
        /// </summary>
        [JsonProperty(PropertyName="seconds")]
        public int Seconds
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets number of milliseconds
        /// </summary>
        [JsonProperty(PropertyName="milliseconds")]
        public int Milliseconds
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets total time milliseconds
        /// </summary>
        [JsonProperty(PropertyName="time")]
        public int TotalMilliseconds
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets the time
        /// </summary>
        public TimeSpan Time => TimeSpan.FromMilliseconds(TotalMilliseconds);

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return Time.ToString();
        }
    }
}