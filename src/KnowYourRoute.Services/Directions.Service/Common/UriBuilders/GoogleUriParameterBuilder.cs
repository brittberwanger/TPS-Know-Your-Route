using System;
using System.Collections.Generic;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;
using KnowYourRoute.Directions.Contracts.Common.UriBuilders;
using KnowYourRoute.Directions.Contracts.Maps.Entities;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Service.Common.UriBuilders
{
    public class GoogleUriParameterBuilder : UriParameterBuilder
    {
        public string ConvertLocationToUriParameters( string key, Location location )
        {
            var locationString = string.Empty;
            if ( addressIsValid( location.Address ) )
                locationString = BuildAddress( location.Address );
            else if ( !string.IsNullOrWhiteSpace( location.PlaceId ) )
                locationString = BuildPlaceId( location.PlaceId );
            else if ( coordinatesAreValid( location.Coordinates ) )
                locationString = BuildCoordinates( location.Coordinates );
            
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
            return $"mode={travelMode.ToString().ToLower()}";
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

        public string BuildMapMarker( MapMarker mapMarker )
        {
            var mapMarkerUriParameter = $"markers=color:{mapMarker.Color}";
            if ( mapMarker.Label != null )
                mapMarkerUriParameter += $"|label:{mapMarker.Label}";

            if ( coordinatesAreValid( mapMarker.Coordinates ) )
                mapMarkerUriParameter += $"|{BuildCoordinates( mapMarker.Coordinates )}";
            else if ( addressIsValid( mapMarker.Address ) )
                mapMarkerUriParameter += $"|{BuildAddress( mapMarker.Address )}";
            else
                return string.Empty;

            return mapMarkerUriParameter;
        }

        private bool coordinatesAreValid( Coordinates coordinates )
        {
            return coordinates.Latitude != default( decimal ) && coordinates.Longitude != default( decimal );
        }

        private bool addressIsValid( Address address )
        {
            return address.StreetAddress1 != default( string )
                   && address.City != default( string )
                   && Enum.IsDefined( typeof( StateCode ), address.StateCode )
                   && address.PostalCode != default( string );
        }


        private int convertDateTimeToUnixTimestamp( DateTime datetime )
        {
            var startingDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var dateTimeDifference = datetime.ToUniversalTime() - startingDateTime;
            return (int)Math.Floor( dateTimeDifference.TotalSeconds );
        }
    }
}
