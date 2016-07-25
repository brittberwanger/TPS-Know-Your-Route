using System.Collections.Generic;
using KnowYourRoute.Directions.Service.Routes.Enumerations;

namespace KnowYourRoute.Directions.Contracts.Routes.Entities
{
    public class DirectionsResponse
    {
        public DirectionsStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<Route> Routes { get; set; }
    }
}
