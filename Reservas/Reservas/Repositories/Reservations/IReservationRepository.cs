using ReservasApi.Models;

namespace ReservasApi.Repositories.Reservations
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAll();
        Task<Reservation> GetById(Guid id);
        Task<Reservation> Create(Reservation reservation);
        Task<Reservation> Update(Reservation reservation);
        Task<Reservation> Delete(Guid id);
    }
}
