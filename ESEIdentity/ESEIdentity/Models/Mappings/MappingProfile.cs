using AutoMapper;
using ESEIdentity.Models;

namespace ESEIdentity.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
