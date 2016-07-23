using System.Threading.Tasks;
using KnowYourRoute.Directions.Contracts.Maps.Entities;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Contracts.Maps.Interfaces
{
    public interface StaticMapRequest
    {
        ImageSize ImageSize { get; set; }
        int Scale { get; set; }
        ImageFormat ImageFormat { get; set; }
        MapPath MapPath { get; set; }

        Task<byte[]> GetStaticMap();
    }

}
