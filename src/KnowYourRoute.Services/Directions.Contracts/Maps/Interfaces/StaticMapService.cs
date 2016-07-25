using System.Threading.Tasks;
using KnowYourRoute.Directions.Contracts.Maps.Entities;

namespace KnowYourRoute.Directions.Contracts.Maps.Interfaces
{
    public interface StaticMapService
    {
        Task<byte[]> GetStaticMap( StaticMapRequest StaticMapRequest );
    }
}
