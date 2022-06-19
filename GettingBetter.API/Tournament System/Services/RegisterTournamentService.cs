using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Shared.Domain.Repositories;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Repositories;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Domain.Services.Communication;

namespace GettingBetter.API.Tournament_System.Services;

public class RegisterTournamentService : IRegisterTournamentService
{ 
   private readonly IRegisterTournamentRepository _registerTournamentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITournamentRepository _tournamentRepository;
    private readonly IStudentRepository _studentRepository;

    public RegisterTournamentService(IRegisterTournamentRepository registerTournamentRepository, IUnitOfWork unitOfWork, IStudentRepository studentRepository,ITournamentRepository tournamentRepository)
    {
        _registerTournamentRepository = registerTournamentRepository;
        _unitOfWork = unitOfWork;
        _tournamentRepository = tournamentRepository;
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<RegisterTournament>> ListAsync()
    {
        return await _registerTournamentRepository.ListAsync();
    }

    public async Task<IEnumerable<RegisterTournament>> ListByTournamentIdAsync(int tournamentId)
    {
        return await _registerTournamentRepository.FindByTournamentIdAsync(tournamentId);
    }

    public async Task<IEnumerable<RegisterTournament>> ListByStudentIdAsync(int studentId)
    {
        return await _registerTournamentRepository.FindByStudentIdAsync(studentId);
    }
    
    public async Task<RegisterTournamentResponse> SaveAsync(RegisterTournament registerTournament)
    {
        

        var existingTournament = await _tournamentRepository.FindByIdAsync(registerTournament.TournamentId);

        if (existingTournament == null)
            return new RegisterTournamentResponse("Invalid Tournament");
        
        // Validate Stuent
       
        var existingStudent = await _studentRepository.FindByIdAsync(registerTournament.StudentId);

        if (existingStudent == null)
            return new RegisterTournamentResponse("Invalid Student"); 
        try
        {
            
            await _registerTournamentRepository.AddAsync(registerTournament);
            
            
            await _unitOfWork.CompleteAsync();
            
            
            return new RegisterTournamentResponse(registerTournament);

        }
        catch (Exception e)
        {
            // Error Handling
            return new RegisterTournamentResponse($"An error occurred while saving the tournament or student: {e.Message}");
        }

        
    }

    public async Task<RegisterTournamentResponse> UpdateAsync(int registerTournamentId, RegisterTournament  registerTournament)
    {
        var existingRegisterTournament = await _registerTournamentRepository.FindByIdAsync(registerTournamentId);
        
        
        if (existingRegisterTournament == null)
            return new RegisterTournamentResponse("RegisterTournament not found.");

    

        var existingTournament = await _registerTournamentRepository.FindByIdAsync(registerTournament.TournamentId);

        if (existingTournament == null)
            return new RegisterTournamentResponse("Invalid Tournament");
       
        
        var existingStudent = await _registerTournamentRepository.FindByIdAsync(registerTournament.StudentId);

        if (existingStudent == null)
            return new RegisterTournamentResponse("Invalid Student");
        // Validate StudentId

       
        
        // Modify Fields
       
        existingRegisterTournament.StudentId = registerTournament.StudentId;
        existingRegisterTournament.TournamentId = registerTournament.TournamentId;


        try
        {
            _registerTournamentRepository.Update(existingRegisterTournament);
            await _unitOfWork.CompleteAsync();

            return new RegisterTournamentResponse(existingRegisterTournament);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new RegisterTournamentResponse($"An error occurred while updating the register of tournament: {e.Message}");
        }

    }

    public async Task<RegisterTournamentResponse> DeleteAsync(int registerTournamentId)
    {
        var existingRegisterTournament = await _registerTournamentRepository.FindByIdAsync(registerTournamentId);
        
        // Validate Tutorial

        if (existingRegisterTournament == null)
            return new RegisterTournamentResponse("Register of tournament not found.");
        
        try
        {
            _registerTournamentRepository.Remove(existingRegisterTournament);
            await _unitOfWork.CompleteAsync();

            return new RegisterTournamentResponse(existingRegisterTournament);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new RegisterTournamentResponse($"An error occurred while deleting the register of tournament: {e.Message}");
        }

    } 
}