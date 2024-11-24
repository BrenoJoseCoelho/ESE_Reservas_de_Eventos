using ReservasApi.Dtos;
using ReservasApi.Request;

namespace ReservasApi.Services.Participants
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantDto>> GetParticipants();
        Task<ParticipantDto> GetParticipantById(Guid id);
        Task AddParticipant(CreateParticipantRequest ParticipantDto);
        Task UpdateParticipant(UpdateParticipantRequest ParticipantDto);
        Task RemoveParticipant(Guid id);
    }
}
