using GettingBetter.API.Advertisement_System.Domain.Models;

namespace GettingBetter.API.Advertisement_System.Domain.Repositories;

public interface IAdvertisementRepository
{
    Task<IEnumerable<Advertisement>> ListAsync();
    Task AddAsync(Advertisement advertisement);
    Task<Advertisement> FindByIdAsync(int advertisementId);
}