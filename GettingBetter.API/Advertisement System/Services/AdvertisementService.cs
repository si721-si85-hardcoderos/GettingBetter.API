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
        _tournamentRepository = tournamentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Advertisement>> ListAsync()
    {
        return await _advertisementRepository.ListAsync();
    }

}