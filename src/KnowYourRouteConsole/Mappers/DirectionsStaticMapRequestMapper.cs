using System;
using System.Collections;
using System.Collections.Generic;
using KnowYourRoute.Directions.Contracts.Maps.Entities;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Service.Maps.Enumerations;
using System.Linq;
using System.Threading.Tasks;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.School.Contracts.Entities;

namespace KnowYourRouteConsole.Mappers
{
    public class DirectionsStaticMapRequestMapper
    {
        public StaticMapRequest ToStaticMapRequest( DirectionsRequest directionsRequest, DirectionsResponse directionsResponse )
        {
            return new StaticMapRequest
            {
                ImageFormat = ImageFormat.PNG8,
                ImageSize = new ImageSize { Height = 1024, Width = 1024 },
                MapPath = new MapPath
                {
                    Color = MapFeatureColor.Blue,
                    EncodedPolyline = directionsResponse.Routes.First().OverviewPolyline,
                    Weight = 5
                },
                Scale = 2,
                MapMarkers = constructMapMarkers( directionsRequest, directionsResponse )
            };
        }

        //public StaticMapRequest ToStaticMapRequest( Student student, DirectionsRequest directionsRequest, DirectionsResponse directionsResponse )
        //{
        //    var encodedPolyline = directionsResponse.Routes.First().OverviewPolyline;
        //    var mapPath = new MapPath
        //    {
        //        Color = MapFeatureColor.Blue,
        //        EncodedPolyline = encodedPolyline,
        //        Weight = 5
        //    };
        //    var mapMarkers = constructMapMarkers( directionsRequest, directionsResponse );
        //    return new StaticMapRequest
        //    {
        //        ImageFormat = ImageFormat.PNG8,
        //        ImageSize = new ImageSize { Height = 1024, Width = 1024 },
        //        MapPath = mapPath,
        //        Scale = 2,
        //        MapMarkers = mapMarkers
        //    };
        //}

        private IEnumerable<MapMarker> constructMapMarkers( DirectionsRequest directionsRequest, DirectionsResponse directionsResponse )
        {
            //var waypointsWithBusStops = traverseDirectionsResponseAndFlattenSteps( directionsResponse ).Where( s => s.HtmlInstructions.StartsWith( "Bus", StringComparison.OrdinalIgnoreCase ));

            //var mapMarkers = getBusStopMapMarkers( waypointsWithBusStops );
            var mapMarkers = new List<MapMarker>();
            addStudentHomeMapMarker( directionsRequest, mapMarkers );
            addSchoolMapMarker( directionsRequest, mapMarkers );

            return mapMarkers;
        }

        private List<MapMarker> getBusStopMapMarkers( IEnumerable<Step> waypointsWithBusStops )
        {
            var mapMarkers = waypointsWithBusStops.Select( w =>
                new MapMarker // Bus Stops
                {
                    Color = MapFeatureColor.Red,
                    Label = 'B',
                    Coordinates = new Coordinates { Latitude = w.StartLocation.Latitude, Longitude = w.StartLocation.Longitude }
                } ).ToList();
            return mapMarkers;
        }

        private static void addStudentHomeMapMarker( DirectionsRequest directionsRequest, List<MapMarker> mapMarkers )
        {
            mapMarkers.Add( new MapMarker // Home
            {
                Color = MapFeatureColor.Blue,
                Label = 'H',
                Address = directionsRequest.OriginLocation.Address,
                Coordinates = directionsRequest.OriginLocation.Coordinates
            } );
        }

        private static void addSchoolMapMarker( DirectionsRequest directionsRequest, List<MapMarker> mapMarkers )
        {
            mapMarkers.Add( new MapMarker // School
            {
                Color = MapFeatureColor.Blue,
                Label = 'S',
                Address = directionsRequest.DestinationLocation.Address,
                Coordinates = directionsRequest.DestinationLocation.Coordinates
            } );
        }
    }
}
