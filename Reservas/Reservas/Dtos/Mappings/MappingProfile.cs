using AutoMapper;
using ReservasApi.Models;

namespace ReservasApi.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationsDto>().ReverseMap();
            CreateMap<Participant, ParticipantDto>().ReverseMap();
        }
    }
}
