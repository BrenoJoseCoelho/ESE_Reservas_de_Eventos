using ReservasApi.Dtos;

namespace ReservasApi.Services.Participants
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantDto>> GetParticipants();
        Task<ParticipantDto> GetParticipantById(Guid id);
        Task AddParticipant(ParticipantDto ParticipantDto);
        Task UpdateParticipant(ParticipantDto ParticipantDto);
        Task RemoveParticipant(Guid id);
    }
}
