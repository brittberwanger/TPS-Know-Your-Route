using System;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRouteConsole.Helpers;

namespace KnowYourRouteConsole.Mappers
{
    public class StudentDirectionsRequestMapper
    {
        public DirectionsRequest ToDirectionsRequest( Student student )
        {
            return new DirectionsRequest
            {
                ArrivalTime = constructArrivalTime( student ),
                OriginLocation = new Location
                {
                    Address = student.Address
                },
                DestinationLocation = new Location
                {
                    Address = student.HighSchool.Address,
                    Coordinates = student.HighSchool.Coordinates,
                    PlaceId = student.HighSchool.GooglePlaceID
                },
                TransitRoutingPreference = TransitRoutingPreference.FewerTransfers,
                TravelMode = TravelMode.Transit
            };
        }

        private DateTime constructArrivalTime( Student student )
        {
            return new DateTime(
                Constants.FirstDayOfSchool.Year,
                Constants.FirstDayOfSchool.Month,
                Constants.FirstDayOfSchool.Day,
                student.HighSchool.BellTimes.SchoolStart.Hour,
                student.HighSchool.BellTimes.SchoolStart.Minute,
                0
                );
        }
    }
}
