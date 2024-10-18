using Microsoft.AspNetCore.Mvc;
using ReservasApi.Dtos;
using ReservasApi.Services.Participants;

namespace ReservasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService ParticipantService)
        {
            _participantService = ParticipantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantDto>>> Get()
        {
            var participantDto = await _participantService.GetParticipants();

            if (participantDto is null)
                return NotFound("Participants not found");

            return Ok(participantDto);
        }

        [HttpGet("{id:Guid}", Name = "GetParticipant")]
        public async Task<ActionResult<ParticipantDto>> Get(Guid id)
        {
            var participantDto = await _participantService.GetParticipantById(id);
            if (participantDto == null)
            {
                return NotFound("Participant not found");
            }
            return Ok(participantDto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ParticipantDto participantDto)
        {
            if (participantDto == null)
                return BadRequest("Invalid Data");

            await _participantService.AddParticipant(participantDto);

            return new CreatedAtRouteResult("GetParticipant", new { id = participantDto.Id },
                participantDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ParticipantDto participantDto)
        {
            if (id != participantDto.Id)
                return BadRequest();

            if (participantDto is null)
                return BadRequest();

            await _participantService.UpdateParticipant(participantDto);

            return Ok(participantDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ParticipantDto>> Delete(Guid id)
        {
            var participantDto = await _participantService.GetParticipantById(id);
            if (participantDto == null)
            {
                return NotFound("Participant not found");
            }

            await _participantService.RemoveParticipant(id);

            return Ok(participantDto);
        }
    }
}
