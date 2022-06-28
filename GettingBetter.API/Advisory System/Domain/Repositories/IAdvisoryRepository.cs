using GettingBetter.API.Advisory_System.Domain.Models;

namespace GettingBetter.API.Advisory_System.Domain.Repositories;

public interface IAdvisoryRepository
{
    Task<IEnumerable<Advisory>> ListAsync();
    Task AddAsync(Advisory advisory);
    Task<Advisory> FindByIdAsync(int advisoryId);
 
    Task<IEnumerable<Advisory>> FindByStudentIdAsync(int studentId);
    Task<IEnumerable<Advisory>> FindByCoachIdAsync(int coachId);
    void Update(Advisory advisory);
    void Remove(Advisory advisory); 
}