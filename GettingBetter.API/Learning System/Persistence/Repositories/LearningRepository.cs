using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Repositories;
using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.Learning_System.Persistence.Repositories;

public class LearningRepository : BaseRepository, ILearningRepository
{
    public LearningRepository(AppDbContext context) : base(context)
    { 
    }
    
    public async Task<IEnumerable<Learning>> ListAsync()
    {
        return await _context.Learnings
            .Include(p => p.Coach)
            .ToListAsync();
            
    }
    
    public async Task AddAsync(Learning learning)
    {
        await _context.Learnings.AddAsync(learning);
    }
    
    public async Task<Learning> FindByIdAsync(int learningId)
    {
        return await _context.Learnings
            .Include(p => p.Coach)
            .Include(p => p.Coach)
            .FirstOrDefaultAsync(p => p.Id == learningId);
        
    }
    
    public void Update(Learning learning)
    {
        _context.Learnings.Update(learning);
    }

    public void Remove(Learning learning)
    {
        _context.Learnings.Remove(learning);
    } 
    
    
}