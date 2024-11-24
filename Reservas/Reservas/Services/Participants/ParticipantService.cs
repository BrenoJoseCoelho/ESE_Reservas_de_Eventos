using AutoMapper;
using ReservasApi.Dtos;
using ReservasApi.Models;
using ReservasApi.Repositories.Participants;
using ReservasApi.Request;

namespace ReservasApi.Services.Participants
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;
        public ParticipantService(IParticipantRepository participantRepository, IMapper mapper)
        {
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantDto>> GetParticipants()
        {
            var participantsEntity = await _participantRepository.GetAll();
            return _mapper.Map<IEnumerable<ParticipantDto>>(participantsEntity);
        }
        public async Task<ParticipantDto> GetParticipantById(Guid id)
        {
            var participantEntity = await _participantRepository.GetById(id);
            return _mapper.Map<ParticipantDto>(participantEntity);
        }
        public async Task AddParticipant(CreateParticipantRequest participantDto)
        {
            var participantEntity = _mapper.Map<Participant>(participantDto);
            await _participantRepository.Create(participantEntity);
        }
        public async Task UpdateParticipant(UpdateParticipantRequest participantDto)
        {
            var participantEntity = _mapper.Map<Participant>(participantDto);
            await _participantRepository.Update(participantEntity);
        }
        public async Task RemoveParticipant(Guid id)
        {
            var participantEntity = _participantRepository.GetById(id).Result;
            await _participantRepository.Delete(participantEntity.Id);
        }
    }
}

