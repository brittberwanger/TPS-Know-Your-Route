using System;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Service.Routes.Enumerations;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class DirectionsRequest
    {
        public bool Alternatives { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public Location OriginLocation { get; set; }

        public Location DestinationLocation { get; set; }

        public TransitRoutingPreference TransitRoutingPreference { get; set; }

        public TravelMode TravelMode { get; set; }
    }
}
