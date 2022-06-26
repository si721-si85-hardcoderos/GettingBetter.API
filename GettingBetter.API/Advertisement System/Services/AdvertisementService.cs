using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Shared.Domain.Repositories;
using GettingBetter.API.Advertisement_System.Domain.Models;
using GettingBetter.API.Advertisement_System.Domain.Repositories;
using GettingBetter.API.Advertisement_System.Domain.Services;
using GettingBetter.API.Advertisement_System.Domain.Services.Communication;

namespace GettingBetter.API.Advertisement_System.Services;

public class AdvertisementService : IAdvertisementService
{ 
   private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AdvertisementService(IAdvertisementRepository advertisementRepository, IUnitOfWork unitOfWork)
    {
        _advertisementRepository = advertisementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Advertisement>> ListAsync()
    {
        return await _advertisementRepository.ListAsync();
    }
    
    public async Task<AdvertisementResponse> SaveAsync(Advertisement advertisement)
        {
            try
            {
                await _advertisementRepository.AddAsync(advertisement);
                await _unitOfWork.CompleteAsync();
                return new AdvertisementResponse(advertisement);
            }
            catch (Exception e)
            {
                return new AdvertisementResponse($"An error occurred while saving the Advertisement: {e.Message}");
            }
        }

        public async Task<AdvertisementResponse> UpdateAsync(int id, Advertisement advertisement)
        {
            var existingAdvertisement = await _advertisementRepository.FindByIdAsync(id);

            if (existingAdvertisement == null)
                return new AdvertisementResponse("Advertisement not found.");

          
           existingAdvertisement.ImageAdvertisement = advertisement.ImageAdvertisement;
           existingAdvertisement.UrlPublication = advertisement.UrlPublication;
           existingAdvertisement.Title = advertisement.Title;
           existingAdvertisement.Description = advertisement.Description;
          


            try
            {
                _advertisementRepository.Update(existingAdvertisement);
                await _unitOfWork.CompleteAsync();

                return new AdvertisementResponse(existingAdvertisement);
            }
            catch (Exception e)
            {
                return new AdvertisementResponse($"An error occurred while updating the advertisement: {e.Message}");
            }
        }

        public async Task<AdvertisementResponse> DeleteAsync(int advertisementId)
        {
            var existingAdvertisement = await _advertisementRepository.FindByIdAsync(advertisementId);

            if (existingAdvertisement == null)
                return new AdvertisementResponse("Advertisement not found.");

            try
            {
                _advertisementRepository.Remove(existingAdvertisement);
                await _unitOfWork.CompleteAsync();

                return new AdvertisementResponse(existingAdvertisement);
            }
            catch (Exception e)
            {
                // Do some logging stuff
                return new AdvertisementResponse($"An error occurred while deleting the advertisement: {e.Message}");
            }
        }
    
}