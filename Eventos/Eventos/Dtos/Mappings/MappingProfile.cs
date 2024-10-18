using AutoMapper;
using EventosApi.Models;

namespace EventosApi.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Enterprise, EnterpriseDto>().ReverseMap();
        }
    }
}
