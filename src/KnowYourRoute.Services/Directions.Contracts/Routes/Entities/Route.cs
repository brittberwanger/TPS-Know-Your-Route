using System.Collections.Generic;
using KnowYourRoute.Directions.Contracts.Common.Entities;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class Route
    {
        [JsonProperty( "summary" )]
        public string Summary { get; set; }

        [JsonProperty( "legs" )]
        public IEnumerable<Leg> Legs { get; set; }

        [JsonProperty( "waypoint_order" )]
        public int[] WaypointOrder { get; set; }

        [JsonProperty( "overview_polyline" )]
        public EncodedPolyline OverviewPolyline { get; set; }

        [JsonProperty( "bounds" )]
        public Bounds Bounds { get; set; }

        [JsonProperty( "copyrights" )]
        public string Copyrights { get; set; }

        [JsonProperty( "warnings" )]
        public IEnumerable<string> Warnings { get; set; }

        [JsonProperty( "fare" )]
        public ValueText Fare { get; set; }
    }
}
