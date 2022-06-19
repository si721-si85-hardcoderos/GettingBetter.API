using GettingBetter.API.Shared.Domain.Services.Communication;
using GettingBetter.API.Tournament_System.Domain.Models;

namespace GettingBetter.API.Tournament_System.Domain.Services.Communication;

public class RegisterTournamentResponse : BaseResponse<RegisterTournament>
{
    public RegisterTournamentResponse(string message) : base(message)
    {
    }

    public RegisterTournamentResponse(RegisterTournament resource) : base(resource)
    {
    } 
}