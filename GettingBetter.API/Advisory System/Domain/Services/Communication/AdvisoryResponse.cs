using GettingBetter.API.Shared.Domain.Services.Communication;
// using GettingBetter.API.Advisory_System.Domain.Models;

namespace GettingBetter.API.Advisory_System.Domain.Services.Communication;

public class AdvisoryResponse : BaseResponse<Domain.Models.Advisory>
{
    public AdvisoryResponse(string message) : base(message)
    {
    }

    public AdvisoryResponse(Domain.Models.Advisory resource) : base(resource)
    {
    } 
}