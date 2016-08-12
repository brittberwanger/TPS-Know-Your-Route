using KnowYourRoute.Common.Contracts.Enumerations;
using System;
using Newtonsoft.Json;

namespace KnowYourRoute.Common.Contracts.Entities
{
    public class Address
    {
        [JsonProperty( "street_address_1" )]
        public string StreetAddress1 { get; set; }

        [JsonProperty( "street_address_2" )]
        public string StreetAddress2 { get; set; }

        [JsonProperty( "city" )]
        public string City { get; set; }

        [JsonProperty( "state" )]
        public StateCode StateCode { get; set; }

        [JsonProperty( "postal_code" )]
        public string PostalCode { get; set; }
    }
}
