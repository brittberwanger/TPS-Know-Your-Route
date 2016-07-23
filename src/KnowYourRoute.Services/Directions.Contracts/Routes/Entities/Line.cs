using System.Collections.Generic;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class Line
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "short_name" )]
        public string ShortName { get; set; }

        [JsonProperty( "color" )]
        public string Color { get; set; }

        [JsonProperty( "agencies" )]
        public IEnumerable<Agency> Agencies { get; set; }

        [JsonProperty( "url" )]
        public string Url { get; set; }

        [JsonProperty( "icon" )]
        public string IconUrl { get; set; }

        [JsonProperty( "text_color" )]
        public string TextColor { get; set; }

        [JsonProperty( "vehicle" )]
        public Vehicle Vehicle { get; set; }
    }
}
