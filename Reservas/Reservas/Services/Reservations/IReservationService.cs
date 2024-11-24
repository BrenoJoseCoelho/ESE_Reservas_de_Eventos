using ReservasApi.Dtos;
using ReservasApi.Request;

namespace ReservasApi.Services.Reservations
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationsDto>> GetReservations();
        Task<ReservationsDto> GetReservationById(Guid id);
        Task AddReservation(CreateReservationRequest reservationDto);
        Task UpdateReservation(UpdateReservationRequest reservationDto);
        Task RemoveReservation(Guid id);
    }
}
