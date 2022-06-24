using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Repositories;
using GettingBetter.API.Learning_System.Domain.Services;
using GettingBetter.API.Shared.Domain.Repositories;

namespace GettingBetter.API.Learning_System.Services;

public class LearningService :ILearningService
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

    public async Task<IEnumerable<Learning>> ListBystudemtIdAsync(int cyberId)
    {
        return await _learningRepository.FindByCyberIdAsync(cyberId);
    }
    
}