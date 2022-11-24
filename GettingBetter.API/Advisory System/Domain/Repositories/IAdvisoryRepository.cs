// using GettingBetter.API.Advisory_System.Domain.Models;

namespace GettingBetter.API.Advisory_System.Domain.Repositories;

public interface IAdvisoryRepository
{
    Task<IEnumerable<Domain.Models.Advisory>> ListAsync();
    Task AddAsync(Domain.Models.Advisory advisory);
    Task<Domain.Models.Advisory> FindByIdAsync(int advisoryId);
 
    Task<IEnumerable<Domain.Models.Advisory>> FindByStudentIdAsync(int studentId);
    Task<IEnumerable<Domain.Models.Advisory>> FindByCoachIdAsync(int coachId);
    void Update(Domain.Models.Advisory advisory);
    void Remove(Domain.Models.Advisory advisory); 
}