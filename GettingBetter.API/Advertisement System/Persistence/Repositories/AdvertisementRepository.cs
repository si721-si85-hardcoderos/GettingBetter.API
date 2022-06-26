using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using GettingBetter.API.Advertisement_System.Domain.Models;
using GettingBetter.API.Advertisement_System.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.Advertisement_System.Persistence.Repositories;

public class AdvertisementRepository : BaseRepository, IAdvertisementRepository
{
    public AdvertisementRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Advertisement>> ListAsync()
    {
        return await _context.Advertisements.ToListAsync();
    }

    public async Task AddAsync(Advertisement advertisement)
    {
        await _context.Advertisements.AddAsync(advertisement);
    }

    public async Task<Advertisement> FindByIdAsync(int  advertisementId)
    {
        return await _context.Advertisements.FindAsync( advertisementId);

    }
    
    public void Update(Advertisement advertisement)
    {
        _context.Advertisements.Update(advertisement);
    }

    public void Remove(Advertisement advertisement)
    {
        _context.Advertisements.Remove(advertisement);
    } 
}
