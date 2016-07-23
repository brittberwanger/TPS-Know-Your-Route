using System.Collections.Generic;
using KnowYourRoute.Directions.Contracts.Common.Entities;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    // TODO: durationInTraffic
    public class Leg
    {
        [JsonProperty( "steps" )]
        public IEnumerable<Step> Steps { get; set; }

        [JsonProperty( "html_instructions" )]
        public string HtmlInstructions { get; set; }

        [JsonProperty( "distance" )]
        public ValueText Distance { get; set; }

        [JsonProperty( "duration" )]
        public ValueText Duration { get; set; }

        [JsonProperty( "arrival_time" )]
        public ValueText ArrivalTime { get; set; }

        [JsonProperty( "departure_time" )]
        public ValueText DepartureTime { get; set; }

        [JsonProperty( "start_location" )]
        public LatLong StartLocation { get; set; }

        [JsonProperty( "end_location" )]
        public LatLong EndLocation { get; set; }

        [JsonProperty( "start_address" )]
        public string StartAddress { get; set; }

        [JsonProperty( "end_address" )]
        public string EndAddress { get; set; }
    }
}
