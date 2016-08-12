using Newtonsoft.Json;

namespace KnowYourRoute.Common.Contracts.Entities
{
    public struct Coordinates
    {
        [JsonProperty( "longitude" )]
        public decimal Longitude { get; set; }

        [JsonProperty( "latitude" )]
        public decimal Latitude { get; set; }
    }
}
