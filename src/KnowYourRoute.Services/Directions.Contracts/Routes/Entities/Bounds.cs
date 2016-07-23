using KnowYourRoute.Directions.Contracts.Common.Entities;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class Bounds
    {
        [JsonProperty( "northeast" )]
        public LatLong NorthEast { get; set; }
        [JsonProperty( "southwest" )]
        public LatLong SouthWest { get; set; } 
    }
}
