using Microsoft.EntityFrameworkCore;
using ReservasApi.Context;
using ReservasApi.Models;

namespace ReservasApi.Repositories.Reservations;

public class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext _context;
    public ReservationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAll()
    {
        return await _context.Reservations.ToListAsync();
    }
    public async Task<Reservation> GetById(Guid id)
    {
        return await _context.Reservations.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Reservation> Create(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }
    public async Task<Reservation> Update(Reservation reservation)
    {
        _context.Entry(reservation).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return reservation;
    }
    public async Task<Reservation> Delete(Guid id)
    {
        var reservation = await GetById(id);
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }
}
