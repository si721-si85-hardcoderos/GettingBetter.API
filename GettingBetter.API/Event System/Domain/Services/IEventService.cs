// using GettingBetter.API.Event_System.Domain.Models;
using GettingBetter.API.Event_System.Domain.Services.Communication;

namespace GettingBetter.API.Event_System.Domain.Services;

public interface IEventService
{
    Task<IEnumerable<Domain.Models.Event>> ListAsync();
    Task<IEnumerable<Domain.Models.Event>> ListByCyberIdAsync(int cyberId);
    Task<EventResponse> SaveAsync(Domain.Models.Event evento);
    Task<EventResponse> UpdateAsync(int eventId, Domain.Models.Event evento);
    Task<EventResponse> DeleteAsync(int eventId);
}