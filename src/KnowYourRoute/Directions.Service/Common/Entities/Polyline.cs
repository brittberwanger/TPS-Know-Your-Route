﻿using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Service.Common.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Polyline
    {
        [JsonProperty( "points" )]
        public string Points { get; set; }
    }
}
