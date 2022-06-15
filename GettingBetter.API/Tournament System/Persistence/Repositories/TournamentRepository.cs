using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.Tournament_System.Persistence.Repositories;

public class TournamentRepository : BaseRepository, ITournamentRepository
{
    public TournamentRepository(AppDbContext context) : base(context)
    { 
    }

    public async Task<IEnumerable<Tournament>> ListAsync()
    {
        return await _context.Tournaments
            .Include(p => p.Cyber)
            .ToListAsync();
            
    }

    public async Task AddAsync(Tournament tournament)
    {
        await _context.Tournaments.AddAsync(tournament);
    }

    public async Task<Tournament> FindByIdAsync(int tournamentId)
    {
        return await _context.Tournaments
            .Include(p => p.Cyber)
            .FirstOrDefaultAsync(p => p.Id == tournamentId);
        
    }
    
    public async Task<IEnumerable<Tournament>> FindByCyberIdAsync(int cyberId)
    {
        return await _context.Tournaments
            .Where(p => p.CyberId == cyberId)
            .Include(p => p.Cyber)
            .ToListAsync();
    }


    public void Update(Tournament tournament)
    {
        _context.Tournaments.Update(tournament);
    }

    public void Remove(Tournament tournament)
    {
        _context.Tournaments.Remove(tournament);
    } 
}