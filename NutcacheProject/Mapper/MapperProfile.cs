using AutoMapper;
using Domain.Entities;

namespace NutcacheProject.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DTOs.EmployeeRequest, Employee>();
            CreateMap<DTOs.Team, Team>();

            CreateMap<Team, DTOs.Team>();
            CreateMap<Employee, DTOs.EmployeeResponse>()
                .ForMember(dest => dest.Team, opt => opt.MapFrom<Team>(src => src.Team));
            
        }
    }
}