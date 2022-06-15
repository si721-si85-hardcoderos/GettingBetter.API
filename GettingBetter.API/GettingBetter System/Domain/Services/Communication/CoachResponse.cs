using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.Shared.Domain.Services.Communication;

namespace GettingBetter.API.GettingBetter_System.Domain.Services.Communication;

public class CoachResponse : BaseResponse<Coach>
{
    public CoachResponse(string message) : base(message)
    {
    }

    public CoachResponse(Coach resource) : base(resource)
    {
    }
}