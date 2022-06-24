using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.Advisory_System.Persistence.Repositories;

public class AdvisoryRepository : BaseRepository, IAdvisoryRepository
{
    public AdvisoryRepository(AppDbContext context) : base(context)
    { 
    }

    public async Task<IEnumerable<Advisory>> ListAsync()
    {
        return await _context.Advisories
            .Include(p => p.Student)
            .Include(p => p.Coach)
            .ToListAsync();
            
    }

    public async Task AddAsync(Advisory advisory)
    {
        await _context.Advisories.AddAsync(advisory);
    }

    public async Task<Advisory> FindByIdAsync(int advisoryId)
    {
        return await _context.Advisories
            .Include(p => p.Student)
            .Include(p => p.Coach)
            .FirstOrDefaultAsync(p => p.Id == advisoryId);
        
    }
    
    public async Task<IEnumerable<Advisory>> FindByStudentIdAsync(int studentId)
    {
        return await _context.Advisories
            .Where(p => p.StudentId == studentId)
            .Include(p => p.Student)
            .ToListAsync();
    }
    public async Task<IEnumerable<Advisory>> FindByCoachIdAsync(int coachId)
    {
        return await _context.Advisories
            .Where(p => p.CoachId == coachId)
            .Include(p => p.Coach)
            .ToListAsync();
    }

    public void Update(Advisory advisory)
    {
        _context.Advisories.Update(advisory);
    }

    public void Remove(Advisory advisory)
    {
        _context.Advisories.Remove(advisory);
    } 
}