using AsapTask.Polygon.Dto;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AsapTask.Polygon
{
    public interface IPolygonService : IApplicationService
    {
        Task CreateAsync(PolygonDataDto polygonDataDto);
    }
}
