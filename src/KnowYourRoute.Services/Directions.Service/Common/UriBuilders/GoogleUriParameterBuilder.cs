using System;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Contracts.Maps.Entities;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using KnowYourRoute.Directions.Service.Maps.Enumerations;
using KnowYourRoute.Directions.Common.Contracts.UriBuilders;

namespace KnowYourRoute.Directions.Service.Common.UriBuilders
{
    public class GoogleUriParameterBuilder : UriParameterBuilder
    {
        public string ConvertLocationToUriParameters( string key, Location location )
        {
            var locationString = string.Empty;
            if ( !string.IsNullOrWhiteSpace( location.PlaceId ) )
                locationString = BuildPlaceId( location.PlaceId );
            else if ( location.Coordinates.IsValid )
                locationString = BuildCoordinates( location.Coordinates );
            else if ( location.Address.IsValid )
                locationString = BuildAddress( location.Address );
            
            return $"{key}={locationString}";
        }


        public string BuildAddress( Address address )
        {
            // TODO: Make replace checks more thorouh
            var formattedStreetAddress = address.StreetAddress1.Replace( ' ', '+' );
            var formattedCity = address.City.Replace( ' ', '+' );
            return $"{formattedStreetAddress}+{formattedCity}+{address.StateCode}+{address.PostalCode}";
        }


        public string BuildCoordinates( Coordinates coordinates )
        {
            return $"{coordinates.Latitude},{coordinates.Longitude}";
        }


        public string BuildPlaceId( string placeId )
        {
            return $"place_id:{placeId}";
        }


        public string BuildDateTime( string key, DateTime dateTime )
        {
            var timestamp = convertDateTimeToUnixTimestamp( dateTime );
            return $"{key}={timestamp}";
        }


        public string BuildTravelMode( TravelMode travelMode )
        {
            return $"mode={travelMode}";
        }



        public string BuildApiKey( string apiKey )
        {
            return $"key={apiKey}";
        }


        public string BuildImageSize( ImageSize imageSize )
        {
            return $"size={imageSize.Width}x{imageSize.Height}";
        }


        public string BuildZoomLevel( int zoomLevel )
        {
            return $"zoom={zoomLevel}";
        }


        public string BuildScale( int scale )
        {
            return $"scale={scale}";
        }


        public string BuildFormat( ImageFormat imageFormat )
        {
            return $"format={imageFormat}";
        }


        public string BuildMapPath( MapPath mapPath )
        {
            return $"path=weight:{mapPath.Weight}|color:{mapPath.Color}|enc:{mapPath.EncodedPolyline.Points.Replace( @"\\", @"\" )}";
        }


        private int convertDateTimeToUnixTimestamp( DateTime datetime )
        {
            var startingDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var dateTimeDifference = datetime.ToUniversalTime() - startingDateTime;
            return (int)Math.Floor( dateTimeDifference.TotalSeconds );
        }
    }
}
