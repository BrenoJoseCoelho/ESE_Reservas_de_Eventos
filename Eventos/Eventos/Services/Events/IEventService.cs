using EventosApi.Dtos;

namespace EventosApi.Services.Events
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEvents();
        Task<EventDto> GetEventById(Guid id);
        Task AddEvent(EventDto eventDto);
        Task UpdateEvent(EventDto eventDto);
        Task RemoveEvent(Guid id);
    }
}
