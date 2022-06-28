using GettingBetter.API.Event_System.Domain.Models;

namespace GettingBetter.API.Event_System.Domain.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> ListAsync();
    Task AddAsync(Event evento);
    Task<Event> FindByIdAsync(int eventId);
    Task<IEnumerable<Event>> FindByCyberIdAsync(int cyberId);
    void Update(Event evento);
    void Remove(Event evento); 
}