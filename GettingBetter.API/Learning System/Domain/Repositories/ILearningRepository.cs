// using GettingBetter.API.Learning_System.Domain.Models;

namespace GettingBetter.API.Learning_System.Domain.Repositories;

public interface ILearningRepository
{
    Task<IEnumerable<Domain.Models.Learning>> ListAsync();
    Task AddAsync(Domain.Models.Learning learning);
    Task<Domain.Models.Learning> FindByIdAsync(int learningId);
 
    Task<IEnumerable<Domain.Models.Learning>> FindByStudentIdAsync(int studentId);
    Task<IEnumerable<Domain.Models.Learning>> FindByCoachIdAsync(int coachId);
    
    void Update(Domain.Models.Learning learning);
    void Remove(Domain.Models.Learning learning); 
}