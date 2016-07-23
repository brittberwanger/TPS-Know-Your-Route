using KnowYourRoute.Directions.Contracts.Common.Entities;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Contracts.Maps.Entities
{
    public class MapPath
    {
        public int Weight { get; set; }

        public MapFeatureColor Color { get; set; }

        public bool GeoDesic { get; set; }

        public EncodedPolyline EncodedPolyline { get; set; }

        public MapPath()
        {
            Color = MapFeatureColor.Blue;
            Weight = 5;
            GeoDesic = false;
        }
    }
}
