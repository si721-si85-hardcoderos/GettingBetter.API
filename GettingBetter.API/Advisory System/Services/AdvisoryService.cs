using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Shared.Domain.Repositories;
using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Domain.Repositories;
using GettingBetter.API.Advisory_System.Domain.Services;
using GettingBetter.API.Advisory_System.Domain.Services.Communication;

namespace GettingBetter.API.Advisory_System.Services;

public class AdvisoryService : IAdvisoryService
{ 
   private readonly IAdvisoryRepository _advisoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;
    private readonly ICoachRepository _coachRepository;

    public AdvisoryService(IAdvisoryRepository advisoryRepository, IUnitOfWork unitOfWork, IStudentRepository studentRepository,ICoachRepository coachRepository)
    {
        _advisoryRepository = advisoryRepository;
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _coachRepository = coachRepository;
    }

    public async Task<IEnumerable<Advisory>> ListAsync()
    {
        return await _advisoryRepository.ListAsync();
    }

    public async Task<IEnumerable<Advisory>> ListByStudentIdAsync(int studentId)
    {
        return await _advisoryRepository.FindByStudentIdAsync(studentId);
    }
    
    public async Task<IEnumerable<Advisory>> ListByCoachIdAsync(int coachId)
    {
        return await _advisoryRepository.FindByCoachIdAsync(coachId);
    }

    public async Task<AdvisoryResponse> SaveAsync(Advisory advisory)
    {
        

        var existingStudent = await _studentRepository.FindByIdAsync(advisory.StudentId);
        

        if (existingStudent == null)
            return new AdvisoryResponse("Invalid Student");
        
        var existingCoach = await _coachRepository.FindByIdAsync(advisory.CoachId);
        
        if (existingCoach==null)
        {
            return new AdvisoryResponse("Invalid Coach");
        }
        // Validate Student
        try
        {
            
            await _advisoryRepository.AddAsync(advisory);
            
            
            await _unitOfWork.CompleteAsync();
            
            
            return new AdvisoryResponse(advisory);

        }
        catch (Exception e)
        {
            // Error Handling
            return new AdvisoryResponse($"An error occurred while saving the advisory: {e.Message}");
        }

        
    }

    public async Task<AdvisoryResponse> UpdateAsync(int advisoryId, Advisory  advisory)
    {
        var existingAdvisory = await _advisoryRepository.FindByIdAsync(advisoryId);
        
 

        if (existingAdvisory == null)
            return new AdvisoryResponse("Advisory not found.");

        // Validate 

        var existingStudent = await _advisoryRepository.FindByIdAsync(advisory.StudentId);

        if (existingStudent == null )
            return new AdvisoryResponse("Invalid Student");
        
        var existingCoach = await _advisoryRepository.FindByIdAsync(advisory.CoachId);
        if (existingCoach == null )
            return new AdvisoryResponse("Invalid Coach");
        
        // Validate StudentId

       
        
        // Modify Fields
        existingAdvisory.AdvisoryImage = advisory.AdvisoryImage;
        existingAdvisory.DiscorServer = advisory.DiscorServer;
        existingAdvisory.Title = advisory.Title;
        existingAdvisory.Description = advisory.Description;
        existingAdvisory.Hour = advisory.Hour;
        existingAdvisory.Date = advisory.Date;

        try
        {
            _advisoryRepository.Update(existingAdvisory);
            await _unitOfWork.CompleteAsync();

            return new AdvisoryResponse(existingAdvisory);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new AdvisoryResponse($"An error occurred while updating the advisory: {e.Message}");
        }

    }

    public async Task<AdvisoryResponse> DeleteAsync(int advisoryId)
    {
        var existingAdvisory = await _advisoryRepository.FindByIdAsync(advisoryId);
        
        // Validate Tutorial

        if (existingAdvisory == null)
            return new AdvisoryResponse("Advisory not found.");
        
        try
        {
            _advisoryRepository.Remove(existingAdvisory);
            await _unitOfWork.CompleteAsync();

            return new AdvisoryResponse(existingAdvisory);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new AdvisoryResponse($"An error occurred while deleting the advisory: {e.Message}");
        }

    } 
}