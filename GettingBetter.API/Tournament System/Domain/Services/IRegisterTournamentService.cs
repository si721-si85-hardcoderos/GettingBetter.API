using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Services.Communication;

namespace GettingBetter.API.Tournament_System.Domain.Services;

public interface IRegisterTournamentService
{
    Task<IEnumerable<RegisterTournament>> ListAsync();
    Task<IEnumerable<RegisterTournament>> ListByStudentIdAsync(int studentId);
    Task<IEnumerable<RegisterTournament>> ListByTournamentIdAsync(int tournamentId);
    Task<RegisterTournamentResponse> SaveAsync(RegisterTournament registerTournament);
    Task<RegisterTournamentResponse> UpdateAsync(int registerTournamentId, RegisterTournament registerTournament);
    Task<RegisterTournamentResponse> DeleteAsync(int registerTournamentId);  
}