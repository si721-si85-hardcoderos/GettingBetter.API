using GettingBetter.API.Shared.Domain.Services.Communication;
// using GettingBetter.API.Event_System.Domain.Models;

namespace GettingBetter.API.Event_System.Domain.Services.Communication;

public class EventResponse : BaseResponse<Domain.Models.Event>
{
    public EventResponse(string message) : base(message)
    {
    }

    public EventResponse(Domain.Models.Event resource) : base(resource)
    {
    } 
}