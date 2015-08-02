// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents information about an auction
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Auction
    {
        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [JsonProperty(PropertyName="auc", Required = Required.Always)]
        public long AuctionId
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the item id
        /// </summary>
        [JsonProperty(PropertyName="item", Required = Required.Always)]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the owner name
        /// </summary>
        [JsonProperty(PropertyName="owner", Required = Required.Always)]
        public string OwnerName
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the bid value in copper
        /// </summary>
        [JsonProperty(PropertyName="bid", Required = Required.Always)]
        public long CurrentBidValue
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the buyout value in copper
        /// </summary>
        [JsonProperty(PropertyName="buyout")]
        public long? BuyoutValue
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the quantity
        /// </summary>
        [JsonProperty(PropertyName="quantity", Required = Required.Always)]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        ///  gets or sets the owner's realm for the auction
        /// </summary>
        [JsonProperty(PropertyName="ownerRealm")]
        public string OwnerRealm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the time left for the auction to expire
        /// </summary>
        [JsonProperty(PropertyName="timeLeft")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuctionTimeLeft TimeLeft
        {
            get;
            set;
        }

        /// <summary>
        /// No clue what this value is about. rand property for auction returned by Blizzard's API
        /// </summary>
        [JsonProperty(PropertyName="rand")]
        public long Random
        {
            get;
            set;
        }

        /// <summary>
        /// No clue what this value is about. seed property for auction returned by Blizzard's API
        /// </summary>
        [JsonProperty(PropertyName="seed")]
        public long Seed
        {
            get;
            set;
        }

        /// <summary>
        /// Pet species Id (in case the auctioned item is a battle pet)
        /// </summary>
        [JsonProperty(PropertyName="petSpeciesId")]
        public int PetSpeciesId
        {
            get;
            set;
        }

        /// <summary>
        /// Pet breed Id (in case the auctioned item is a battle pet)
        /// </summary>
        [JsonProperty(PropertyName="petBreedId")]
        public int PetBreedId
        {
            get;
            set;
        }

        /// <summary>
        /// Pet level (in case the auctioned item is a battle pet)
        /// </summary>
        [JsonProperty(PropertyName="petLevel")]
        public int PetLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Pet quality (in case the auctioned item is a battle pet)
        /// </summary>
        [JsonProperty(PropertyName="petQualityId")]
        public ItemQuality PetQuality
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
            return $"Auction {AuctionId}, Item Id {ItemId}, Owner {OwnerName}, Bid {CurrentBidValue}, Buyout {BuyoutValue}, Quantity {Quantity}";
        }
    }
}