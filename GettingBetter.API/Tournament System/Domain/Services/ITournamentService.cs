using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Services.Communication;

namespace GettingBetter.API.Tournament_System.Domain.Services;

public interface ITournamentService
{
    Task<IEnumerable<Tournament>> ListAsync();
    Task<IEnumerable<Tournament>> ListByCyberIdAsync(int cyberId);
    Task<TournamentResponse> SaveAsync(Tournament tournament);
    Task<TournamentResponse> UpdateAsync(int tournamentId, Tournament tournament);
    Task<TournamentResponse> DeleteAsync(int tournamentId);  
}