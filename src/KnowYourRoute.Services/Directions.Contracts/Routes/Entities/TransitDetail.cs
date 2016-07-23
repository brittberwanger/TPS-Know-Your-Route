using KnowYourRoute.Directions.Contracts.Common.Entities;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class TransitDetails
    {
        [JsonProperty( "arrival_stop" )]
        public Stop ArrivalStop { get; set; }

        [JsonProperty( "departure_stop" )]
        public Stop DepartureStop { get; set; }

        [JsonProperty( "arrival_time" )]
        public ValueText ArrivalTime { get; set; }

        [JsonProperty( "departure_time" )]
        public ValueText DepartureTime { get; set; }

        [JsonProperty( "headsign" )]
        public string HeadSign { get; set; }

        // TODO: Convert to minutes
        [JsonProperty( "headway" )]
        public int HeadWay { get; set; }

        [JsonProperty( "num_stops" )]
        public int NumberOfStops { get; set; }

        [JsonProperty( "line" )]
        public Line Line { get; set; }
    }
}
