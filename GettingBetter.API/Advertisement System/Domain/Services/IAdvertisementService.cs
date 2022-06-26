using GettingBetter.API.Advertisement_System.Domain.Models;
using GettingBetter.API.Advertisement_System.Domain.Services.Communication;

namespace GettingBetter.API.Advertisement_System.Domain.Services;

public interface IAdvertisementService
{
    Task<IEnumerable<Advertisement>> ListAsync();
    Task<AdvertisementResponse> SaveAsync(Advertisement advertisement);
    Task<AdvertisementResponse> UpdateAsync(int advertisementId, Advertisement advertisement);
    Task<AdvertisementResponse> DeleteAsync(int advertisementId);
}