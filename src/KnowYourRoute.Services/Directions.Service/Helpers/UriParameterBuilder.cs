using System;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Contracts.Maps.Entities;
using KnowYourRoute.Directions.Service.Maps.Enumerations;
using KnowYourRoute.Directions.Service.Routes.Enumerations;

namespace KnowYourRoute.Directions.Service.Helpers
{
    public interface UriParameterBuilder
    {
        string ConvertLocationToUriParameters( string key, Location location );


        string BuildAddress( Address address );


        string BuildCoordinates( Coordinates coordinates );


        string BuildPlaceId( string placeId );


        string BuildDateTime( string key, DateTime dateTime );


        string BuildTravelMode( TravelMode travelMode );


        string BuildApiKey( string apiKey );


        string BuildImageSize( ImageSize imageSize );


        string BuildZoomLevel( int zoomLevel );


        string BuildScale( int scale );


        string BuildFormat( ImageFormat imageFormat );


        string BuildMapPath( MapPath mapPath );
    }
}
