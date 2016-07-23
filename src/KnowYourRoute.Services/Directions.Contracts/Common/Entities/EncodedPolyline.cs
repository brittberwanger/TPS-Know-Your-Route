using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Common.Entities
{
    public class EncodedPolyline
    {
        [JsonProperty( "points" )]
        public string Points { get; set; }
    }
}
