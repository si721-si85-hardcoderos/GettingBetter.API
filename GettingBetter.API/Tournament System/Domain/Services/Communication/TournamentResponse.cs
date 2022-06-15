using GettingBetter.API.Shared.Domain.Services.Communication;
using GettingBetter.API.Tournament_System.Domain.Models;

namespace GettingBetter.API.Tournament_System.Domain.Services.Communication;

public class TournamentResponse : BaseResponse<Tournament>
{
    public TournamentResponse(string message) : base(message)
    {
    }

    public TournamentResponse(Tournament resource) : base(resource)
    {
    } 
}