using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourRoute.Directions.Service.Common.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LatLong
    {
        [JsonProperty( "lng" )]
        public decimal LongitudeX { get; set; }

        [JsonProperty( "lat" )]
        public decimal LatitudeY { get; set; }
    }
}
