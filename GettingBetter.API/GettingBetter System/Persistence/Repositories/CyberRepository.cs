using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.GettingBetter_System.Persistence.Repositories;


public class CyberRepository : BaseRepository, ICyberRepository
{
    public CyberRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Cyber>> ListAsync()
    {
        return await _context.Cybers.ToListAsync();
    }

    public async Task AddAsync(Cyber cyber)
    {
        await _context.Cybers.AddAsync(cyber);
    }

    public async Task<Cyber> FindByIdAsync(int  cyberId)
    {
        return await _context.Cybers.FindAsync( cyberId);

    }
    
    public void Update(Cyber cyber)
    {
        _context.Cybers.Update(cyber);
    }

    public void Remove(Cyber cyber)
    {
        _context.Cybers.Remove(cyber);
    } 
}
