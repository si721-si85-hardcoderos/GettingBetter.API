using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Shared.Domain.Services.Communication;

namespace GettingBetter.API.Learning_System.Domain.Services.Communication;

public class LearningResponse : BaseResponse<Learning>
{
    public LearningResponse(string message) : base(message)
    {
    }

    public LearningResponse(Learning resource) : base(resource)
    {
    } 
}