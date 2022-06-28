using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Domain.Services.Communication;

namespace GettingBetter.API.Advisory_System.Domain.Services;

public interface IAdvisoryService
{
    Task<IEnumerable<Advisory>> ListAsync();
    Task<IEnumerable<Advisory>> ListByStudentIdAsync(int studentId);
    Task<IEnumerable<Advisory>> ListByCoachIdAsync(int coachId);
    Task<AdvisoryResponse> SaveAsync(Advisory advisory);
    Task<AdvisoryResponse> UpdateAsync(int advisoryId, Advisory advisory);
    Task<AdvisoryResponse> DeleteAsync(int advisoryId);  
}