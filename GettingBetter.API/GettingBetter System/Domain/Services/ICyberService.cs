using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Services.Communication;

namespace GettingBetter.API.GettingBetter_System.Domain.Services;


    public interface ICyberService
    {
        Task<IEnumerable<Cyber>> ListAsync();
        // Task<IEnumerable<Student>> ListByCoachIdAsync(int coachId);
        Task<CyberResponse> SaveAsync(Cyber cyber);
        Task<CyberResponse> UpdateAsync(int cyberId, Cyber cyber);
        Task<CyberResponse> DeleteAsync(int cyberId);
    }

