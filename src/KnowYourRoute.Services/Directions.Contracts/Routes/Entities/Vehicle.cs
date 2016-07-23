using KnowYourRoute.Directions.Service.Routes.Enumerations;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class Vehicle
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "type" )]
        public VehicleType VehicleType { get; set; }

        [JsonProperty( "icon" )]
        public string IconUrl { get; set; }

        [JsonProperty( "local_icon" )]
        public string LocalIconUrl { get; set; }
    }
}
