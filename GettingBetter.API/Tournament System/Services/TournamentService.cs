using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Shared.Domain.Repositories;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Repositories;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Domain.Services.Communication;

namespace GettingBetter.API.Tournament_System.Services;

public class TournamentService : ITournamentService
{ 
   private readonly ITournamentRepository _tournamentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICyberRepository _cyberRepository;

    public TournamentService(ITournamentRepository tournamentRepository, IUnitOfWork unitOfWork, ICyberRepository cyberRepository)
    {
        _tournamentRepository = tournamentRepository;
        _unitOfWork = unitOfWork;
        _cyberRepository = cyberRepository;
    }

    public async Task<IEnumerable<Tournament>> ListAsync()
    {
        return await _tournamentRepository.ListAsync();
    }

    public async Task<IEnumerable<Tournament>> ListByCyberIdAsync(int cyberId)
    {
        return await _tournamentRepository.FindByCyberIdAsync(cyberId);
    }

    public async Task<TournamentResponse> SaveAsync(Tournament tournament)
    {
        

        var existingCyber = await _cyberRepository.FindByIdAsync(tournament.CyberId);

        if (existingCyber == null)
            return new TournamentResponse("Invalid Cyber");
        
        // Validate Stuent
        try
        {
            
            await _tournamentRepository.AddAsync(tournament);
            
            
            await _unitOfWork.CompleteAsync();
            
            
            return new TournamentResponse(tournament);

        }
        catch (Exception e)
        {
            // Error Handling
            return new TournamentResponse($"An error occurred while saving the tournament: {e.Message}");
        }

        
    }

    public async Task<TournamentResponse> UpdateAsync(int tournamentId, Tournament  tournament)
    {
        var existingTournament = await _tournamentRepository.FindByIdAsync(tournamentId);
        
 

        if (existingTournament == null)
            return new TournamentResponse("Tournament not found.");

        // Validate CyberId

        var existingCyber = await _tournamentRepository.FindByIdAsync(tournament.CyberId);

        if (existingCyber == null)
            return new TournamentResponse("Invalid Cyber");
        
        // Validate StudentId

       
        
        // Modify Fields
        existingTournament.Title = tournament.Title;
        existingTournament.Addres = tournament.Addres;
        existingTournament.Date = tournament.Date;
        existingTournament.Description = tournament.Description;

        try
        {
            _tournamentRepository.Update(existingTournament);
            await _unitOfWork.CompleteAsync();

            return new TournamentResponse(existingTournament);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new TournamentResponse($"An error occurred while updating the tournament: {e.Message}");
        }

    }

    public async Task<TournamentResponse> DeleteAsync(int tournamentId)
    {
        var existingTournament = await _tournamentRepository.FindByIdAsync(tournamentId);
        
        // Validate Tutorial

        if (existingTournament == null)
            return new TournamentResponse("Tournament not found.");
        
        try
        {
            _tournamentRepository.Remove(existingTournament);
            await _unitOfWork.CompleteAsync();

            return new TournamentResponse(existingTournament);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new TournamentResponse($"An error occurred while deleting the tournament: {e.Message}");
        }

    } 
}