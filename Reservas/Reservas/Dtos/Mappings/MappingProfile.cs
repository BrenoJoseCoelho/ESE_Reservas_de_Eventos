using AutoMapper;
using ReservasApi.Models;
using ReservasApi.Request;

namespace ReservasApi.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationsDto>().ReverseMap();
            CreateMap<Participant, ParticipantDto>().ReverseMap();
            CreateMap<UpdateParticipantRequest, Participant>().ReverseMap();
            CreateMap<CreateParticipantRequest, Participant>().ReverseMap();
            CreateMap<UpdateReservationRequest, Reservation>().ReverseMap();
            CreateMap<CreateReservationRequest, Reservation>().ReverseMap();
        }
    }
}
