using System;
using System.Net.Http;
using System.Threading.Tasks;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using Newtonsoft.Json;
using KnowYourRoute.Directions.Contracts.Common.Configuration;
using KnowYourRoute.Directions.Common.Contracts.UriBuilders;

namespace KnowYourRoute.Directions.Service.Routes.Services
{
    public class GoogleDirectionsRequest
    {
        private static readonly Uri _baseUri = new Uri( "https://maps.googleapis.com/maps/api/directions/" );

        private const string OUTPUT_FORMAT = "json?";

        private readonly ApiOptions _apiOptions;

        private readonly UriParameterBuilder _uriParameterBuilder;
        
        public Location OriginLocation { get; set; }
        public Location DestinationLocation { get; set; }
        
        public TravelMode TravelMode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; } // TODO: Pad the first bell time?
        
        public bool Alternatives { get; set; }
        public TransitRoutingPreference TransitRoutingPreference { get; set; }

        public GoogleDirectionsRequest( ApiOptions apiOptions, UriParameterBuilder uriParameterBuilder )
        {
            _apiOptions = apiOptions;
            _uriParameterBuilder = uriParameterBuilder;
        }


        public async Task<GoogleDirectionsResponse> GetDirections()
        {
            using ( var client = new HttpClient() )
            {
                client.BaseAddress = _baseUri;
                var response = await client.GetAsync( constructUriParameters() );
                // TODO: Take out
                Console.WriteLine( $"{_baseUri}{constructUriParameters()}" );

                if ( !response.IsSuccessStatusCode )
                    throw new Exception( $"{response.StatusCode}: {response.ReasonPhrase}" );

                var responseString = await response.Content.ReadAsStringAsync();
                // TODO: Take out
                //Console.WriteLine( responseString );
                return JsonConvert.DeserializeObject<GoogleDirectionsResponse>( responseString );
            }
        }

    
        private string constructUriParameters()
        {
            var parameters = OUTPUT_FORMAT;

            parameters += _uriParameterBuilder.ConvertLocationToUriParameters( "origin", OriginLocation );
            parameters += "&" + _uriParameterBuilder.ConvertLocationToUriParameters( "destination", DestinationLocation );
            parameters += "&" + _uriParameterBuilder.BuildDateTime( "arrival_time", ArrivalTime );
            parameters += "&" + _uriParameterBuilder.BuildTravelMode( TravelMode );
            parameters += "&" + _uriParameterBuilder.BuildApiKey( _apiOptions.ApiKey );

            return parameters;
        }
    }
}
