using System;
using System.Threading.Tasks;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using KnowYourRoute.Directions.Service.Routes.Services;

namespace KnowYourRoute.Directions.Contracts.Routes.Interfaces
{
    public interface DirectionsRequest
    {
        bool Alternatives { get; set; }
        DateTime ArrivalTime { get; set; }
        DateTime DepartureTime { get; set; }
        Location OriginLocation { get; set; }
        Location DestinationLocation { get; set; }
        TransitRoutingPreference TransitRoutingPreference { get; set; }
        TravelMode TravelMode { get; set; }

        Task<GoogleDirectionsResponse> GetDirections();
    }
}
