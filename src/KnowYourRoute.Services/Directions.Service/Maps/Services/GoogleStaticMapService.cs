using System;
using System.Net.Http;
using System.Threading.Tasks;
using KnowYourRoute.Directions.Contracts.Maps.Interfaces;
using KnowYourRoute.Directions.Contracts.Common.Configuration;
using KnowYourRoute.Directions.Contracts.Common.UriBuilders;
using KnowYourRoute.Directions.Contracts.Maps.Entities;

namespace KnowYourRoute.Directions.Service.Maps.Services
{
    public class GoogleStaticMapService : StaticMapService
    {
        private static readonly Uri _baseUri = new Uri( "https://maps.googleapis.com/maps/api/" );

        private const string API_SPECIFIER = "staticmap?";

        private readonly ApiOptions _apiOptions;
        private readonly UriParameterBuilder _uriParameterBuilder;

        public GoogleStaticMapService( ApiOptions apiOptions, UriParameterBuilder uriParameterBuilder )
        {
            _apiOptions = apiOptions;
            _uriParameterBuilder = uriParameterBuilder;
        }


        public async Task<byte[]> GetStaticMap( StaticMapRequest staticMapRequest )
        {
            using ( var client = new HttpClient() )
            {
                client.BaseAddress = _baseUri;
                var response = await client.GetAsync( constructUriParameters( staticMapRequest ) );

                if ( !response.IsSuccessStatusCode )
                    throw new Exception( $"{response.StatusCode}: {response.ReasonPhrase}" );

                var responseBytes = await response.Content.ReadAsByteArrayAsync();
                return responseBytes;
            }
        }


        private string constructUriParameters( StaticMapRequest staticMapRequest )
        {
            var parameters = API_SPECIFIER;

            parameters += _uriParameterBuilder.BuildImageSize( staticMapRequest.ImageSize );
            parameters += "&" + _uriParameterBuilder.BuildScale( staticMapRequest.Scale );
            parameters += "&" + _uriParameterBuilder.BuildFormat( staticMapRequest.ImageFormat );
            parameters += "&" + _uriParameterBuilder.BuildMapPath( staticMapRequest.MapPath );
            parameters += "&" + _uriParameterBuilder.BuildApiKey( _apiOptions.ApiKey );

            return parameters;
        }
    }
}
