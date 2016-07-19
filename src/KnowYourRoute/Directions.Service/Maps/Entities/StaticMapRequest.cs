using System;
using System.Net.Http;
using System.Threading.Tasks;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Service.Common.Entities;
using KnowYourRoute.Directions.Service.Configuration;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Service.Maps.Entities
{
    // TODO: Convert Zoom Level to Int? Document rankings?
    // TODO: language, region
    public class StaticMapRequest
    {
        private static Uri _baseUri = new Uri( "https://maps.googleapis.com/maps/api/" );

        private GoogleMapsApiOptions _googleMapsApiOptions;

        // TODO: How do we determine center?? use bounding box from directions api?
        public Coordinates Center { get; set; }

        // TODO: Make sure ZoomLevel captures whole route
        public int ZoomLevel { get; set; }
        public Size Size { get; set; }
        public int? Scale { get; set; }
        public ImageFormat ImageFormat { get; set; }
        public Polyline Polyline { get; set; }

        public StaticMapRequest( GoogleMapsApiOptions apiOptions )
        {
            _googleMapsApiOptions = apiOptions;

            this.Size = new Size { Width = Constants.SIZE_MAX_WIDTH_FREE, Height = Constants.SIZE_MAX_HEIGHT_FREE };
            this.ZoomLevel = 13;
            this.Scale = 2;
            this.ImageFormat = ImageFormat.PNG8;
        }


        public async Task<byte[]> GetStaticMap()
        {
            using ( var client = new HttpClient() )
            {
                client.BaseAddress = _baseUri;
                var response = await client.GetAsync( constructUriParameters() );
                var responseBytes = await response.Content.ReadAsByteArrayAsync();
                return responseBytes;
            }
        }


        public Uri ToUri()
        {
            return new Uri( _baseUri, constructUriParameters() );
        }

        private string constructUriParameters()
        {
            var parameters = "staticmap?";

            // TODO: Optional if providing encoded polyline
            //parameters += convertCenterToUriParameters();
            // TODO: Optional if providing encoded polyline
            //parameters += "&" + convertZoomLevelToUriParameters();

            parameters += convertSizeToUriParameters();
            parameters += "&" + convertScaleToUriParameters();
            parameters += "&" + convertFormatToUriParameters();
            parameters += "&" + convertPolylineToUriParameters();
            parameters += "&" + convertApiKeyToUriParameters();

            return parameters;
        }

        private string convertPolylineToUriParameters()
        {
            return string.Format( "path=color:Orange|weight:5|enc:{0}", Polyline.Points );
        }

        private string convertApiKeyToUriParameters()
        {
            return string.Format( "key={0}", _googleMapsApiOptions.ApiKey );
        }

        private string convertFormatToUriParameters()
        {
            return string.Format( "format={0}", ImageFormat );
        }

        // TODO: What if null?
        private string convertScaleToUriParameters()
        {
            return string.Format( "scale={0}", Scale );
        }

        private string convertSizeToUriParameters()
        {
            return string.Format( "size={0}x{1}", Size.Width, Size.Height );
        }

        private string convertZoomLevelToUriParameters()
        {
            return string.Format( "zoom={0}", (int)ZoomLevel );
        }

        private string convertCenterToUriParameters()
        {
            return string.Format( "center={0},{1}", Center.LatitudeY, Center.LongitudeX );
        }
    }
}
