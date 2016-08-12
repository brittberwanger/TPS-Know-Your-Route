using System;
using System.Net.Http;
using System.Threading.Tasks;
using KnowYourRoute.Directions.Contracts.Common.Configuration;
using KnowYourRoute.Directions.Contracts.Common.UriBuilders;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Contracts.Routes.Interfaces;
using Newtonsoft.Json;

namespace KnowYourRoute.Directions.Service.Routes.Services
{
    public class GoogleDirectionsService : DirectionsService
    {
        private static readonly Uri _baseUri = new Uri( "https://maps.googleapis.com/maps/api/directions/" );
        private const string OUTPUT_FORMAT = "json?";

        private readonly ApiOptions _apiOptions;
        private readonly UriParameterBuilder _uriParameterBuilder;


        public GoogleDirectionsService( ApiOptions apiOptions, UriParameterBuilder uriParameterBuilder )
        {
            _apiOptions = apiOptions;
            _uriParameterBuilder = uriParameterBuilder;
        }


        public async Task<DirectionsResponse> GetDirections( DirectionsRequest directionsRequest )
        {
            try
            {
                using ( var client = new HttpClient() )
                {
                    client.BaseAddress = _baseUri;
                    var response = await client.GetAsync( _baseUri + constructUriParameters( directionsRequest ) );

                    if ( !response.IsSuccessStatusCode )
                        throw new Exception( $"{response.StatusCode}: {response.ReasonPhrase}" );

                    var responseString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DirectionsResponse>( responseString );
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.Message );
                Console.WriteLine( ex.StackTrace );
                if ( ex.InnerException != null )
                {
                    Console.WriteLine( ex.InnerException.Message );
                    Console.WriteLine( ex.InnerException.StackTrace );
                }

                return new DirectionsResponse();
            }
        }


        private string constructUriParameters( DirectionsRequest directionsRequest )
        {
            var parameters = OUTPUT_FORMAT;

            parameters += _uriParameterBuilder.ConvertLocationToUriParameters( "origin", directionsRequest.OriginLocation );
            parameters += "&" + _uriParameterBuilder.ConvertLocationToUriParameters( "destination", directionsRequest.DestinationLocation );
            parameters += "&" + _uriParameterBuilder.BuildDateTime( "arrival_time", directionsRequest.ArrivalTime );
            parameters += "&" + _uriParameterBuilder.BuildTravelMode( directionsRequest.TravelMode );
            parameters += "&" + _uriParameterBuilder.BuildApiKey( _apiOptions.ApiKey );

            return parameters;
        }
    }
}
