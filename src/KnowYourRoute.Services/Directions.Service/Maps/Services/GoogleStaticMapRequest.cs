using System;
using System.Net.Http;
using System.Threading.Tasks;
using KnowYourRoute.Directions.Contracts.Maps.Entities;
using KnowYourRoute.Directions.Contracts.Maps.Interfaces;
using KnowYourRoute.Directions.Service.Configuration;
using KnowYourRoute.Directions.Service.Helpers;
using KnowYourRoute.Directions.Service.Maps.Enumerations;
using KnowYourRoute.Directions.Service.Maps.Validation;

namespace KnowYourRoute.Directions.Service.Maps.Services
{
    public class GoogleStaticMapRequest : StaticMapRequest
    {
        private static readonly Uri _baseUri = new Uri( "https://maps.googleapis.com/maps/api/" );

        private const string API_SPECIFIER = "staticmap?";

        private readonly ApiOptions _apiOptions;
        private readonly UriParameterBuilder _uriParameterBuilder;

        public ImageSize ImageSize { get; set; }
        public int Scale { get; set; }
        public ImageFormat ImageFormat { get; set; }

        public MapPath MapPath { get; set; }

        public GoogleStaticMapRequest( ApiOptions apiOptions, UriParameterBuilder uriParameterBuilder )
        {
            _apiOptions = apiOptions;
            _uriParameterBuilder = uriParameterBuilder;

            this.ImageSize = new ImageSize { Width = GoogleStaticMapRequestValidation.IMAGE_SIZE_MAX_WIDTH_FREE, Height = GoogleStaticMapRequestValidation.IMAGE_SIZE_MAX_HEIGHT_FREE };
            this.Scale = GoogleStaticMapRequestValidation.SCALE_MAX_FREE;
            this.ImageFormat = ImageFormat.PNG8;
        }


        public async Task<byte[]> GetStaticMap()
        {
            using ( var client = new HttpClient() )
            {
                client.BaseAddress = _baseUri;
                var response = await client.GetAsync( constructUriParameters() );

                if ( !response.IsSuccessStatusCode )
                    throw new Exception( $"{response.StatusCode}: {response.ReasonPhrase}" );

                var responseBytes = await response.Content.ReadAsByteArrayAsync();
                return responseBytes;
            }
        }


        private string constructUriParameters()
        {
            var parameters = API_SPECIFIER;

            parameters += _uriParameterBuilder.BuildImageSize( ImageSize );
            parameters += "&" + _uriParameterBuilder.BuildScale( Scale );
            parameters += "&" + _uriParameterBuilder.BuildFormat( ImageFormat );
            parameters += "&" + _uriParameterBuilder.BuildMapPath( MapPath );
            parameters += "&" + _uriParameterBuilder.BuildApiKey( _apiOptions.ApiKey );

            return parameters;
        }
    }
}
