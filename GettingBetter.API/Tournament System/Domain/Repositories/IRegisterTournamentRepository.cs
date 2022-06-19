using GettingBetter.API.Tournament_System.Domain.Models;

namespace GettingBetter.API.Tournament_System.Domain.Repositories;

public interface IRegisterTournamentRepository
{
    Task<IEnumerable<RegisterTournament>> ListAsync();
    Task AddAsync(RegisterTournament registerTournament);
    Task<RegisterTournament> FindByIdAsync(int registerTournamentId);
    Task<IEnumerable<RegisterTournament>> FindByTournamentIdAsync(int tournamentId);
    Task<IEnumerable<RegisterTournament>> FindByStudentIdAsync(int studentId);
    void Update(RegisterTournament registerTournament);
    void Remove(RegisterTournament registerTournament); 
}