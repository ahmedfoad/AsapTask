using AutoMapper;
using AsapTask.Models;
using AsapTask.Polygon.Dto;

namespace AsapTask.Roles.Dto
{
    public class PolygonDataMapProfile : Profile
    {
        public PolygonDataMapProfile()
        {
            CreateMap<PolygonDataDto, PolygonData>();
            CreateMap<PolygonData, PolygonDataDto>();

        }
    }
}
