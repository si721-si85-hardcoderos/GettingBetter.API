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

    public async Task AddAsync(Advertisement advertisement)
    {
        await _context.Advertisements.AddAsync(advertisement);
    }
}