using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Common.Entities
{
    public class LatLong
    {
        [JsonProperty( "lng" )]
        public decimal Longitude { get; set; }

        [JsonProperty( "lat" )]
        public decimal Latitude { get; set; }
    }
}
