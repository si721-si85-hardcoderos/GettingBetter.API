using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using GettingBetter.API.Event_System.Domain.Models;
using GettingBetter.API.Event_System.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.Event_System.Persistence.Repositories;

public class EventRepository : BaseRepository, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    { 
    }

    public async Task<IEnumerable<Event>> ListAsync()
    {
        return await _context.Events
            .Include(p => p.Cyber)
            .ToListAsync();
            
    }

    public async Task AddAsync(Event event)
    {
        await _context.Events.AddAsync(event);
    }

    public async Task<Event> FindByIdAsync(int eventId)
    {
        return await _context.Events
            .Include(p => p.Cyber)
            .FirstOrDefaultAsync(p => p.Id == eventId);
        
    }
    
    public async Task<IEnumerable<Event>> FindByCyberIdAsync(int cyberId)
    {
        return await _context.Events
            .Where(p => p.CyberId == cyberId)
            .Include(p => p.Cyber)
            .ToListAsync();
    }


    public void Update(Event event)
    {
        _context.Events.Update(event);
    }

    public void Remove(Event event)
    {
        _context.Events.Remove(event);
    } 
}