using System.Collections.Generic;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Contracts.Maps.Entities
{
    public class StaticMapRequest
    {
        public ImageSize ImageSize { get; set; }

        public int Scale { get; set; }

        public ImageFormat ImageFormat { get; set; }

        public MapPath MapPath { get; set; }

        public IEnumerable<MapMarker> MapMarkers { get; set; }
    }

}
