using ReservasApi.Dtos;

namespace ReservasApi.Services.Reservations
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationsDto>> GetReservations();
        Task<ReservationsDto> GetReservationById(Guid id);
        Task AddReservation(ReservationsDto reservationDto);
        Task UpdateReservation(ReservationsDto reservationDto);
        Task RemoveReservation(Guid id);
    }
}
