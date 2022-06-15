using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.Tournaments_System.Domain.Models;

namespace GettingBetter.API.Tournaments_System.Domain.Repositories;

public interface ITournamentRepository
{
    Task<IEnumerable<Tournament>> ListAsync();
    Task AddAsync(Tournament tournament);
    Task<Tournament> FindByIdAsync(int tournamentId);
  //  Task<IEnumerable<Student>> FindByStudentIdAsync(int studentId);
    Task<IEnumerable<Tournament>> FindByCyberIdAsync(int cyberId);
    void Update(Tournament tournament);
    void Remove(Tournament tournament); 
}