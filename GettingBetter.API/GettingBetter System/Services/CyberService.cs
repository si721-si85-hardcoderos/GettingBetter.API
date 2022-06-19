using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.GettingBetter_System.Domain.Services;
using GettingBetter.API.GettingBetter_System.Domain.Services.Communication;
using GettingBetter.API.Shared.Domain.Repositories;


namespace GettingBetter.API.GettingBetter_System.Services;


    public class CyberService : ICyberService
    {
        private readonly ICyberRepository _cyberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CyberService(ICyberRepository cyberRepository, IUnitOfWork unitOfWork)
        {
            _cyberRepository = cyberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cyber>> ListAsync()
        {
            return await _cyberRepository.ListAsync();
        }

        public async Task<CyberResponse> SaveAsync(Cyber cyber)
        {
            try
            {
                await _cyberRepository.AddAsync(cyber);
                await _unitOfWork.CompleteAsync();
                return new CyberResponse(cyber);
            }
            catch (Exception e)
            {
                return new CyberResponse($"An error occurred while saving the Cyber: {e.Message}");
            }
        }

        public async Task<CyberResponse> UpdateAsync(int id, Cyber cyber)
        {
            var existingCyber = await _cyberRepository.FindByIdAsync(id);

            if (existingCyber == null)
                return new CyberResponse("Cyber not found.");

          
           existingCyber.FirstName = cyber.FirstName;
           existingCyber.LastName = cyber.LastName;
           existingCyber.Password = cyber.Password;
           existingCyber.CyberName = cyber.CyberName;
           existingCyber.CyberImage = cyber.CyberImage;
           existingCyber.Bibliography = cyber.Bibliography;
           existingCyber.Email = cyber.Email;
           existingCyber.Password = cyber.Password;


            try
            {
                _cyberRepository.Update(existingCyber);
                await _unitOfWork.CompleteAsync();

                return new CyberResponse(existingCyber);
            }
            catch (Exception e)
            {
                return new CyberResponse($"An error occurred while updating the cyber: {e.Message}");
            }
        }

        public async Task<CyberResponse> DeleteAsync(int cyberId)
        {
            var existingCyber = await _cyberRepository.FindByIdAsync(cyberId);

            if (existingCyber == null)
                return new CyberResponse("Cyber not found.");

            try
            {
                _cyberRepository.Remove(existingCyber);
                await _unitOfWork.CompleteAsync();

                return new CyberResponse(existingCyber);
            }
            catch (Exception e)
            {
                // Do some logging stuff
                return new CyberResponse($"An error occurred while deleting the cyber: {e.Message}");
            }
        }
    }

