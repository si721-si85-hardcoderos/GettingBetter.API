// using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Services.Communication;

namespace GettingBetter.API.Learning_System.Domain.Services;

public interface ILearningService
{
    Task<IEnumerable<Domain.Models.Learning>> ListAsync();
    Task<IEnumerable<Domain.Models.Learning>> ListByStudentIdAsync(int cyberId);
    Task<IEnumerable<Domain.Models.Learning>> ListByCoachIdAsync(int cyberId);

    
    Task<LearningResponse> SaveAsync(Domain.Models.Learning learning);
    Task<LearningResponse> UpdateAsync(int learningId, Domain.Models.Learning learning);
    Task<LearningResponse> DeleteAsync(int learningId);  
}