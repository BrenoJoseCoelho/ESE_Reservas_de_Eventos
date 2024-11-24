using Microsoft.EntityFrameworkCore;
using ReservasApi.Context;
using ReservasApi.Dtos;
using ReservasApi.Models;
using System.Text.Json;

namespace ReservasApi.Repositories.Participants
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public ParticipantRepository(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ParticipantDto>> GetAll()
        {
            var participants = await _context.Participants.IgnoreQueryFilters().ToListAsync();
            List<ParticipantDto> participantDto = new List<ParticipantDto>();
            foreach (var participant in participants)
            {
                var responseUser = await _httpClient.GetAsync($"http://host.docker.internal:8083/api/user/{participant.UserId}");

                var userDto = new UserDto();
                if (responseUser.IsSuccessStatusCode)
                {
                    var jsonString = await responseUser.Content.ReadAsStringAsync();
                    userDto = JsonSerializer.Deserialize<UserDto>(jsonString);

                }
                participantDto.Add(new ParticipantDto
                {
                    Id = participant.Id,
                    Name = participant.Name,
                    Document = participant.Document,
                    User = userDto

                });

            }

            return participantDto;

        }
        public async Task<Participant> GetById(Guid id)
        {
            return await _context.Participants.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Participant> Create(Participant Enterprise)
        {
            _context.Participants.Add(Enterprise);
            await _context.SaveChangesAsync();
            return Enterprise;
        }
        public async Task<Participant> Update(Participant Enterprise)
        {
            _context.Entry(Enterprise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Enterprise;
        }
        public async Task<Participant> Delete(Guid id)
        {
            var Enterprise = await GetById(id);
            _context.Participants.Remove(Enterprise);
            await _context.SaveChangesAsync();
            return Enterprise;
        }
    }
}
