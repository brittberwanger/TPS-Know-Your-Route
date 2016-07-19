using System;
using System.Net.Http;
using System.Threading.Tasks;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Service.Configuration;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Service.Routes.Entities
{
    // TODO: Language, units, region, trafficmodel, transitRoutingPreference
    // TODO: Exceptions for required parameters
    public class DirectionsRequest
    {
        private static Uri _baseUri = new Uri( "https://maps.googleapis.com/maps/api/directions/" );

        private GoogleMapsApiOptions _googleMapsApiOptions;

        #region Location
        public Address OriginAddress { get; set; }
        public Coordinates OriginCoordinates { get; set; }
        public string OriginPlaceId { get; set; }

        public Address DestinationAddress { get; set; }
        public Coordinates DestinationCoordinates { get; set; }
        public string DestinationPlaceId { get; set; }
        #endregion

        #region Travel Mode Options
        public TravelMode TravelMode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; } // TODO: Pad the first bell time?
        #endregion

        public bool Alternatives { get; set; }
        public TransitRoutingPreference TransitRoutingPreference { get; set; }

        public DirectionsRequest( GoogleMapsApiOptions apiOptions )
        {
            _googleMapsApiOptions = apiOptions;
        }


        public async Task<DirectionsResponse> GetDirections()
        {
            // TODO: Try/Catch
            using ( var client = new HttpClient() )
            {
                client.BaseAddress = _baseUri;
                var response = await client.GetAsync( constructUriParameters() );
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine( responseString );
                return JsonConvert.DeserializeObject<DirectionsResponse>( responseString );
            }
        }

        // TODO: Make private after testing
        private string constructUriParameters()
        {
            var parameters = specifyOutputFormat();

            parameters += convertOriginToUriParameters();
            parameters += "&" + convertDestinationToUriParameters();
            parameters += "&" + convertArrivalTimeToUriParameters();
            parameters += "&" + convertTravelModeToUriParameters();
            parameters += "&" + convertApiKeyToUriParameters();

            return parameters;
        }

        private string specifyOutputFormat()
        {
            return "json?";
        }

        private string convertOriginToUriParameters()
        {
            var origin = string.Empty;
            if ( !string.IsNullOrWhiteSpace( OriginPlaceId ) )
                origin = convertPlaceIdToUriParameters( OriginPlaceId );
            else if ( OriginCoordinates.IsValid )
                origin = convertCoordinatesToUriParameters( OriginCoordinates );
            else if ( OriginAddress.IsValid )
                origin = convertAddressToUriParameters( OriginAddress );

            return string.Format( "origin={0}", origin );
        }

        private string convertDestinationToUriParameters()
        {
            var destination = string.Empty;
            if ( !string.IsNullOrWhiteSpace( DestinationPlaceId ) )
                destination = convertPlaceIdToUriParameters( DestinationPlaceId );
            else if ( DestinationCoordinates.IsValid )
                destination = convertCoordinatesToUriParameters( DestinationCoordinates );
            else if ( DestinationAddress.IsValid )
                destination = convertAddressToUriParameters( DestinationAddress );

            return string.Format( "destination={0}", destination );
        }

        private string convertArrivalTimeToUriParameters()
        {
            return string.Format( "arrival_time={0}", convertToUnixTimestamp( ArrivalTime ) );
        }

        private string convertTravelModeToUriParameters()
        {
            return string.Format( "mode={0}", TravelMode );
        }

        private string convertApiKeyToUriParameters()
        {
            return string.Format( "key={0}", _googleMapsApiOptions.ApiKey );
        }


        private string convertPlaceIdToUriParameters( string placeId )
        {
            return string.Format( "place_id:{0}", placeId );
        }

        // TODO: Should this have a key?
        private string convertCoordinatesToUriParameters( Coordinates coordinates )
        {
            return string.Format( "{0},{1}", coordinates.LatitudeY, coordinates.LongitudeX );
        }

        // TODO: Should this have a key?
        private string convertAddressToUriParameters( Address address )
        {
            // TODO: Make replace checks more thorouh
            var formattedStreetAddress = address.StreetAddress1.Replace( ' ', '+' );
            var formattedCity = address.City.Replace( ' ', '+' );
            return string.Format( "{0}+{1}+{2}+{3}", formattedStreetAddress, formattedCity, address.StateCode, address.PostalCode );
        }


        private int convertToUnixTimestamp( DateTime datetime )
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = datetime.ToUniversalTime() - origin;
            return (int)Math.Floor( diff.TotalSeconds );
        }
    }
}
