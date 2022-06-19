using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.GettingBetter_System.Domain.Services;
using GettingBetter.API.GettingBetter_System.Domain.Services.Communication;
using GettingBetter.API.Shared.Domain.Repositories;


namespace GettingBetter.API.GettingBetter_System.Services;

public class CoachService : ICoachService
{
    private readonly ICoachRepository _coachRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CoachService(ICoachRepository coachRepository, IUnitOfWork unitOfWork)
    {
        _coachRepository = coachRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Coach>> ListAsync()
    {
        return await _coachRepository.ListAsync();
    }

    public async Task<CoachResponse> SaveAsync(Coach coach)
    {
        try
        {
            await _coachRepository.AddAsync(coach);
            await _unitOfWork.CompleteAsync();
            return new CoachResponse(coach);
        }
        catch (Exception e)
        {
            return new CoachResponse($"An error occurred while saving the coach: {e.Message}");
        }
    }

    public async Task<CoachResponse> UpdateAsync(int id, Coach coach)
    {
        var existingCoach = await _coachRepository.FindByIdAsync(id);

        if (existingCoach == null)
            return new CoachResponse("Coach not found.");

        existingCoach.FirstName = coach.FirstName;
        existingCoach.LastName = coach.LastName;
        existingCoach.Password = coach.Password;
        existingCoach.NickName = coach.NickName;
        existingCoach.SelectedGame = coach.SelectedGame;
        existingCoach.Bibliography = coach.Bibliography;
        existingCoach.UserImage = existingCoach.UserImage;

        try
        {
            _coachRepository.Update(existingCoach);
            await _unitOfWork.CompleteAsync();

            return new CoachResponse(existingCoach);
        }
        catch (Exception e)
        {
            return new CoachResponse($"An error occurred while updating the coach: {e.Message}");
        }
    }

    public async Task<CoachResponse> DeleteAsync(int id)
    {
        var existingCoach = await _coachRepository.FindByIdAsync(id);

        if (existingCoach == null)
            return new CoachResponse("Coach not found.");

        try
        {
            _coachRepository.Remove(existingCoach);
            await _unitOfWork.CompleteAsync();

            return new CoachResponse(existingCoach);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CoachResponse($"An error occurred while deleting the coach: {e.Message}");
        }
    }
}