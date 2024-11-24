using Microsoft.EntityFrameworkCore;
using ReservasApi.Context;
using ReservasApi.Dtos;
using ReservasApi.Models;
using System.Text.Json;

namespace ReservasApi.Repositories.Reservations;

public class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public ReservationRepository(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ReservationsDto>> GetAll()
    {
        var reservations = await _context.Reservations.Include(c => c.Participant).ToListAsync();
        List<ReservationsDto> reservationDto = new List<ReservationsDto>();
        foreach (var reservation in reservations)
        {
            var reservationResult = new ReservationsDto
            {
                Id = reservation.Id,
            };

            var responseEvent = await _httpClient.GetAsync($"http://host.docker.internal:8081/api/event/{reservation.EventId}");

            if (responseEvent.IsSuccessStatusCode)
            {
                var jsonString = await responseEvent.Content.ReadAsStringAsync();
                var eventDto = JsonSerializer.Deserialize<EventDto>(jsonString);
                reservationResult.Event = eventDto;
            }


            var responseCoupon = await _httpClient.GetAsync($"http://host.docker.internal:8084/api/coupon/{reservation.CouponId}");

            if (responseCoupon.IsSuccessStatusCode)
            {
                var jsonString = await responseCoupon.Content.ReadAsStringAsync();
                var couponDto = JsonSerializer.Deserialize<CouponDto>(jsonString);
                reservationResult.Coupon = couponDto;
            }

            reservationDto.Add(reservationResult);
        }
        return reservationDto;
    }
    public async Task<Reservation> GetById(Guid id)
    {
        return await _context.Reservations.Include(c => c.Participant).Where(c => c.Id == id).FirstOrDefaultAsync();
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
