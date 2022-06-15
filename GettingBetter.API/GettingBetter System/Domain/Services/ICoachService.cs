using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Services.Communication;

namespace GettingBetter.API.GettingBetter_System.Domain.Services;

public interface ICoachService
{
    Task<IEnumerable<Coach>> ListAsync();
    Task<CoachResponse> SaveAsync(Coach coach);
    Task<CoachResponse> UpdateAsync(int id, Coach coach);
    Task<CoachResponse> DeleteAsync(int id); 
}