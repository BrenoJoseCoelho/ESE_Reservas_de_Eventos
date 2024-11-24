using Microsoft.AspNetCore.Mvc;
using ReservasApi.Dtos;
using ReservasApi.Request;
using ReservasApi.Services.Reservations;

namespace ReservasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService ReservationService)
        {
            _reservationService = ReservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationsDto>>> Get()
        {
            var reservationDto = await _reservationService.GetReservations();

            if (reservationDto is null)
                return NotFound("Reservations not found");

            return Ok(reservationDto);
        }

        [HttpGet("{id:Guid}", Name = "GetReservation")]
        public async Task<ActionResult<ReservationsDto>> Get(Guid id)
        {
            var reservationDto = await _reservationService.GetReservationById(id);
            if (reservationDto == null)
            {
                return NotFound("Reservation not found");
            }
            return Ok(reservationDto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateReservationRequest reservationDto)
        {
            if (reservationDto == null)
                return BadRequest("Invalid Data");

            await _reservationService.AddReservation(reservationDto);

            return new CreatedAtRouteResult("GetReservation",
                reservationDto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateReservationRequest reservationDto)
        {
            if (id != reservationDto.Id)
                return BadRequest();

            if (reservationDto is null)
                return BadRequest();

            await _reservationService.UpdateReservation(reservationDto);

            return Ok(reservationDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ReservationsDto>> Delete(Guid id)
        {
            var reservationDto = await _reservationService.GetReservationById(id);
            if (reservationDto == null)
            {
                return NotFound("Reservation not found");
            }

            await _reservationService.RemoveReservation(id);

            return Ok(reservationDto);
        }
    }
}
