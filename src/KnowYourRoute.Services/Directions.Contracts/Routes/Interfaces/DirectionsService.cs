using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Service.Routes.Services;

namespace KnowYourRoute.Directions.Contracts.Routes.Interfaces
{
    public interface DirectionsService
    {
        Task<DirectionsResponse> GetDirections( DirectionsRequest directionsRequest );
    }
}
