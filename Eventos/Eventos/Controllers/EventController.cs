using EventosApi.Dtos;
using EventosApi.Services.Events;
using Microsoft.AspNetCore.Mvc;

namespace EventosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _EventService;

        public EventController(IEventService EventService)
        {
            _EventService = EventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> Get()
        {
            var EventsDto = await _EventService.GetEvents();

            if (EventsDto is null)
                return NotFound("Events not found");

            return Ok(EventsDto);
        }

        [HttpGet("{id:Guid}", Name = "GetEvent")]
        public async Task<ActionResult<EventDto>> Get(Guid id)
        {
            var EventDto = await _EventService.GetEventById(id);
            if (EventDto == null)
            {
                return NotFound("Event not found");
            }
            return Ok(EventDto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventDto eventDto)
        {
            if (eventDto == null)
                return BadRequest("Invalid Data");

            await _EventService.AddEvent(eventDto);

            return new CreatedAtRouteResult("GetEvent", new { id = eventDto.Id },
                eventDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] EventDto eventDto)
        {
            if (id != eventDto.Id)
                return BadRequest();

            if (eventDto is null)
                return BadRequest();

            await _EventService.UpdateEvent(eventDto);

            return Ok(eventDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EventDto>> Delete(Guid id)
        {
            var EventDto = await _EventService.GetEventById(id);
            if (EventDto == null)
            {
                return NotFound("Event not found");
            }

            await _EventService.RemoveEvent(id);

            return Ok(EventDto);
        }
    }
}
