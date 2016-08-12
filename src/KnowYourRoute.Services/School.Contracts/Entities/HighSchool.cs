using KnowYourRoute.Common.Contracts.Entities;
using Newtonsoft.Json;

namespace KnowYourRoute.School.Contracts.Entities
{
    [JsonObject( "high_school" )]
    public class HighSchool
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "google_place_id" )]
        public string GooglePlaceID { get; set; }

        [JsonProperty( "address" )]
        public Address Address { get; set; }

        [JsonProperty( "coordinates" )]
        public Coordinates Coordinates { get; set; }

        [JsonProperty( "bell_times" )]
        public BellTimes BellTimes { get; set; }
    }
}
