using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Service.Maps.Entities
{
    // TODO: Color type? Color enum based on predefined colors: https://developers.google.com/maps/documentation/static-maps/intro#Markers
    // TOODO: Icon?
    public class MapMarker
    {
        public MapMarkerSize Size { get; set; }
        public string Color { get; set; }
        public char? Label { get; set; }
        public Address Address { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
