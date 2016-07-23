using System.Collections.Generic;
using KnowYourRoute.Directions.Contracts.Common.Entities;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class Step
    {
        [JsonProperty( "html_instructions" )]
        public string HtmlInstructions { get; set; }

        [JsonProperty( "distance" )]
        public ValueText Distance { get; set; }

        [JsonProperty( "duration" )]
        public ValueText Duration { get; set; }

        [JsonProperty( "start_location" )]
        public LatLong StartLocation { get; set; }

        [JsonProperty( "end_location" )]
        public LatLong EndLocation { get; set; }

        [JsonProperty( "polyline" )]
        public EncodedPolyline Polyline { get; set; }

        [JsonProperty( "steps" )]
        public IEnumerable<Step> Steps { get; set; }

        [JsonProperty( "transit_details" )]
        public TransitDetails TransitDetails { get; set; }
    }
}
