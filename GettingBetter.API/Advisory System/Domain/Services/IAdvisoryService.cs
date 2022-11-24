// using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Domain.Services.Communication;

namespace GettingBetter.API.Advisory_System.Domain.Services;

public interface IAdvisoryService
{
    Task<IEnumerable<Domain.Models.Advisory>> ListAsync();
    Task<IEnumerable<Domain.Models.Advisory>> ListByStudentIdAsync(int studentId);
    Task<IEnumerable<Domain.Models.Advisory>> ListByCoachIdAsync(int coachId);
    Task<AdvisoryResponse> SaveAsync(Domain.Models.Advisory advisory);
    Task<AdvisoryResponse> UpdateAsync(int advisoryId, Domain.Models.Advisory advisory);
    Task<AdvisoryResponse> DeleteAsync(int advisoryId);  
}