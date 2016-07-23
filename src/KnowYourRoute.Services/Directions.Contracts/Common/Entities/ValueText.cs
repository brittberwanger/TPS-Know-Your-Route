﻿using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Contracts.Common.Entities
{
    public class ValueText
    {
        [JsonProperty( "value" )]
        public string Value { get; set; }

        [JsonProperty( "text" )]
        public string Text { get; set; }
    }
}
