using GettingBetter.API.Tournament_System.Domain.Models;

namespace GettingBetter.API.Tournament_System.Domain.Repositories;

public interface ITournamentRepository
{
    Task<IEnumerable<Tournament>> ListAsync();
    Task AddAsync(Tournament tournament);
    Task<Tournament> FindByIdAsync(int tournamentId);
 
    Task<IEnumerable<Tournament>> FindByCyberIdAsync(int cyberId);
    void Update(Tournament tournament);
    void Remove(Tournament tournament); 
}