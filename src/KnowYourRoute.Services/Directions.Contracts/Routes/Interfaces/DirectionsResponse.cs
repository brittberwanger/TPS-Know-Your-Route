using System.Collections.Generic;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Service.Routes.Enumerations;

namespace KnowYourRoute.Directions.Contracts.Routes.Interfaces
{
    public interface DirectionsResponse
    {
        DirectionsStatusCode StatusCode { get; set; }

        string ErrorMessage { get; set; }

        IEnumerable<Route> Routes { get; set; }
    }
}
