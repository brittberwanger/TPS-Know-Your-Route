using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class Agency
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "url" )]
        public string Url { get; set; }

        [JsonProperty( "phone" )]
        public string Phone { get; set; }
    }
}
