using Microsoft.EntityFrameworkCore;
using ReservasApi.Context;
using ReservasApi.Models;

namespace ReservasApi.Repositories.Participants
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AppDbContext _context;
        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Participant>> GetAll()
        {
            return await _context.Participants.ToListAsync();
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
