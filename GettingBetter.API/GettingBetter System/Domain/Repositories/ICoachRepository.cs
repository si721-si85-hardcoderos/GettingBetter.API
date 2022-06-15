using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.GettingBetter_System.Domain.Repositories;

public interface ICoachRepository
{
    Task<IEnumerable<Coach>> ListAsync();
    Task AddAsync(Coach coach);
    Task<Coach> FindByIdAsync(int id);
    void Update(Coach coach);
    void Remove(Coach coach);
}