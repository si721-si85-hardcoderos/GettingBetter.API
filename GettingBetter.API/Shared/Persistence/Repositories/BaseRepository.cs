using GettingBetter.API.Shared.Persistence.Contexts;

namespace GettingBetter.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    } 
}