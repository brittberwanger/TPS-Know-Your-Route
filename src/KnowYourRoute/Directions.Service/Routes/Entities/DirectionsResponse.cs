using KnowYourRoute.Directions.Service.Routes.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace KnowYourRoute.Directions.Service.Routes.Entities
{
    public class DirectionsResponse
    {
        [JsonProperty( "status" )]
        [JsonConverter( typeof( StringEnumConverter ) )]
        public DirectionsStatusCode StatusCode { get; set; }

        [JsonProperty( "error_message" )]
        public string ErrorMessage { get; set; }

        [JsonProperty( "routes" )]
        public IEnumerable<Route> Routes { get; set; }
    }
}
