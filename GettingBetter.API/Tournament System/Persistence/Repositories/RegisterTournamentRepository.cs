using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.Tournament_System.Persistence.Repositories;

public class RegisterTournamentRepository : BaseRepository, IRegisterTournamentRepository
{
    public RegisterTournamentRepository(AppDbContext context) : base(context)
    { 
    }

    public async Task<IEnumerable<RegisterTournament>> ListAsync()
    {
        return await _context.RegisterTournaments
            .Include(p => p.Tournament)
            .Include(a=>a.Student)
            .ToListAsync();
            
    }

    public async Task AddAsync(RegisterTournament registerTournament)
    {
        await _context.RegisterTournaments.AddAsync(registerTournament);
    }

    public async Task<RegisterTournament> FindByIdAsync(int registerTournamentId)
    {
        return await _context.RegisterTournaments
            .Include(p => p.Tournament)
            .Include(a=> a.Student)
            .FirstOrDefaultAsync(p => p.Id == registerTournamentId);
        
    }
    
    public async Task<IEnumerable<RegisterTournament>> FindByTournamentIdAsync(int tournamentId)
    {
        return await _context.RegisterTournaments
            .Where(p => p.TournamentId == tournamentId)
            .Include(p => p.Tournament)
            .ToListAsync();
    }
    public async Task<IEnumerable<RegisterTournament>> FindByStudentIdAsync(int studentId)
    {
        return await _context.RegisterTournaments
            .Where(p => p.StudentId == studentId)
            .Include(p => p.Student)
            .ToListAsync();
    }

    public void Update(RegisterTournament registerTournament)
    {
        _context.RegisterTournaments.Update(registerTournament);
    }

    public void Remove(RegisterTournament registerTournament)
    {
        _context.RegisterTournaments.Remove(registerTournament);
    } 
}