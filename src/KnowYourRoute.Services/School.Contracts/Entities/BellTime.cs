using System;
using Newtonsoft.Json;

namespace KnowYourRoute.School.Contracts.Entities
{
    public class BellTimes
    {
        // TODO: Better way to represent bell times
        // TODO: Handle to 24HourTime
        [JsonProperty( "school_start" )]
        public Time SchoolStart { get; set; }

        [JsonProperty( "school_end" )]
        public Time SchoolEnd { get; set; }
    }
}