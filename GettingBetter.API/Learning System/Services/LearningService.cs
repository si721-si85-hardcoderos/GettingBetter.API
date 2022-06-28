using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Repositories;
using GettingBetter.API.Learning_System.Domain.Services;
using GettingBetter.API.Learning_System.Domain.Services.Communication;
using GettingBetter.API.Shared.Domain.Repositories;
using GettingBetter.API.Tournament_System.Domain.Services.Communication;

namespace GettingBetter.API.Learning_System.Services;

public class LearningService : ILearningService
{
    private readonly ILearningRepository _learningRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICoachRepository _coachRepository;
    private readonly IStudentRepository _studentRepository;
    
    public LearningService(ILearningRepository learningRepository, IUnitOfWork unitOfWork, ICoachRepository coachRepository, IStudentRepository studentRepository )
    {
        _learningRepository = learningRepository;
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
        _coachRepository = coachRepository;
    }
    
    public async Task<IEnumerable<Learning>> ListAsync()
    {
        return await _learningRepository.ListAsync();
    }

    public async Task<IEnumerable<Learning>> ListByStudentIdAsync(int studentId)
    {
        return await _learningRepository.FindByStudentIdAsync(studentId);
    }
    
    public async Task<IEnumerable<Learning>> ListByCoachIdAsync(int coachId)
    {
        return await _learningRepository.FindByCoachIdAsync(coachId);
    }
    
    public async Task<LearningResponse> SaveAsync(Learning learning)
    {
        

        var existingStudent = await _studentRepository.FindByIdAsync(learning.StudentId);

        if (existingStudent == null)
            return new LearningResponse("Invalid Student"); 
        
        // Validate Stuent
       
        var existingCoach= await _coachRepository.FindByIdAsync(learning.CoachId);

        if (existingCoach == null)
            return new LearningResponse("Invalid Coach"); 
        try
        {
            
            await _learningRepository.AddAsync(learning);
            
            
            await _unitOfWork.CompleteAsync();
            
            
            return new LearningResponse(learning);

        }
        catch (Exception e)
        {
            // Error Handling
            return new LearningResponse($"An error occurred while saving the coach or student: {e.Message}");
        }

        
    }
    
     public async Task<LearningResponse> UpdateAsync(int learningId, Learning  learning)
    {
        var existingLearning = await _learningRepository.FindByIdAsync(learningId);
        
        if (existingLearning == null)
            return new LearningResponse("Learning not found.");

    

        var existingStudent = await _learningRepository.FindByIdAsync(learning.StudentId);

        if (existingStudent == null)
            return new LearningResponse("Cant Change ID value");

        var existingCoach= await _learningRepository.FindByIdAsync(learning.CoachId);

        if (existingCoach == null)
            return new LearningResponse("Cant Change ID value"); 
        // Validate StudentId

       
        
        // Modify Fields
       
        existingLearning.StudentId = learning.StudentId;
        existingLearning.CoachId = learning.CoachId;


        try
        {
            _learningRepository.Update(existingLearning);
            await _unitOfWork.CompleteAsync();

            return new LearningResponse(existingLearning);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new LearningResponse($"An error occurred while updating the register of coach or student: {e.Message}");
        }

    }

    public async Task<LearningResponse> DeleteAsync(int learningId)
    {
        var existingLearning = await _learningRepository.FindByIdAsync(learningId);
        
        // Validate Tutorial

        if (existingLearning == null)
            return new LearningResponse("Learning not found.");
        
        try
        {
            _learningRepository.Remove(existingLearning);
            await _unitOfWork.CompleteAsync();

            return new LearningResponse(existingLearning);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new LearningResponse($"An error occurred while deleting the register of coach or student from learning: {e.Message}");
        }

    } 
    
    
}