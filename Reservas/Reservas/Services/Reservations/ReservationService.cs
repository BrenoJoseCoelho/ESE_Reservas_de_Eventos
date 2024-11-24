using AutoMapper;
using ReservasApi.Dtos;
using ReservasApi.Models;
using ReservasApi.Repositories.Reservations;
using ReservasApi.Request;

namespace ReservasApi.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationsDto>> GetReservations()
        {
            var reservationsEntity = await _reservationRepository.GetAll();
            return _mapper.Map<IEnumerable<ReservationsDto>>(reservationsEntity);
        }
        public async Task<ReservationsDto> GetReservationById(Guid id)
        {
            var reservationEntity = await _reservationRepository.GetById(id);
            return _mapper.Map<ReservationsDto>(reservationEntity);
        }
        public async Task AddReservation(CreateReservationRequest reservationDto)
        {
            var reservationEntity = _mapper.Map<Reservation>(reservationDto);
            await _reservationRepository.Create(reservationEntity);
        }
        public async Task UpdateReservation(UpdateReservationRequest reservationDto)
        {
            var reservationEntity = _mapper.Map<Reservation>(reservationDto);
            await _reservationRepository.Update(reservationEntity);
        }
        public async Task RemoveReservation(Guid id)
        {
            var reservationEntity = _reservationRepository.GetById(id).Result;
            await _reservationRepository.Delete(reservationEntity.Id);
        }
    }
}
