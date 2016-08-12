using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourRoute.Directions.Contracts.Routes.Entities;

namespace KnowYourRouteConsole.DirectionsResponses
{
    public class StudentDirectionsResponse
    {
        public string StudentId { get; set; }
        public DirectionsResponse DirectionsResponse { get; set; }
    }
}
