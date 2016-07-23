using System.Collections.Generic;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Contracts.Routes.Interfaces;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KnowYourRoute.Directions.Service.Routes.Services
{
    public class GoogleDirectionsResponse : DirectionsResponse
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
