using GettingBetter.API.Event_System.Domain.Models;
using GettingBetter.API.Event_System.Domain.Services.Communication;

namespace GettingBetter.API.Event_System.Domain.Services;

public interface IEventService
{
    Task<IEnumerable<Event>> ListAsync();
    Task<IEnumerable<Event>> ListByCyberIdAsync(int cyberId);
    Task<EventResponse> SaveAsync(Event evento);
    Task<EventResponse> UpdateAsync(int eventId, Event evento);
    Task<EventResponse> DeleteAsync(int eventId);
}