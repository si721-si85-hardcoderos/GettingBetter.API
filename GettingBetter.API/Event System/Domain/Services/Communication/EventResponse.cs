using GettingBetter.API.Shared.Domain.Services.Communication;
using GettingBetter.API.Event_System.Domain.Models;

namespace GettingBetter.API.Event_System.Domain.Services.Communication;

public class EventResponse : BaseResponse<Event>
{
    public EventResponse(string message) : base(message)
    {
    }

    public EventResponse(Event resource) : base(resource)
    {
    } 
}