using GettingBetter.API.Event_System.Domain.Models;

namespace GettingBetter.API.Event_System.Domain.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> ListAsync();
    Task AddAsync(Event event);
    Task<Event> FindByIdAsync(int eventId);
 
    Task<IEnumerable<Event>> FindByCyberIdAsync(int cyberId);
    void Update(Event event);
    void Remove(Event event); 
}