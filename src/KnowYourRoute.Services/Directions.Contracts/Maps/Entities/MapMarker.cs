using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Contracts.Maps.Entities
{
    // TODO: Icon?
    public class MapMarker
    {
        public MapMarkerSize Size { get; set; }
        public MapFeatureColor Color { get; set; }
        // TODO: Check if null in UriParameterBuilder
        public char? Label { get; set; }
        public Address Address { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
