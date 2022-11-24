// using GettingBetter.API.Event_System.Domain.Models;

namespace GettingBetter.API.Event_System.Domain.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Domain.Models.Event>> ListAsync();
    Task AddAsync(Domain.Models.Event evento);
    Task<Domain.Models.Event> FindByIdAsync(int eventId);
    Task<IEnumerable<Domain.Models.Event>> FindByCyberIdAsync(int cyberId);
    void Update(Domain.Models.Event evento);
    void Remove(Domain.Models.Event evento); 
}