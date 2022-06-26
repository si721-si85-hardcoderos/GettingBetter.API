using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Services.Communication;

namespace GettingBetter.API.Learning_System.Domain.Services;

public interface ILearningService
{
    Task<IEnumerable<Learning>> ListAsync();
    Task<IEnumerable<Learning>> ListByStudentIdAsync(int cyberId);
    Task<IEnumerable<Learning>> ListByCoachIdAsync(int cyberId);

    
    Task<LearningResponse> SaveAsync(Learning learning);
    Task<LearningResponse> UpdateAsync(int learningId, Learning learning);
    Task<LearningResponse> DeleteAsync(int learningId);  
}