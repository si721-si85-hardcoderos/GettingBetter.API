using GettingBetter.API.Shared.Domain.Services.Communication;
using GettingBetter.API.Advertisement_System.Domain.Models;

namespace GettingBetter.API.Advertisement_System.Domain.Services.Communication;

public class AdvertisementResponse : BaseResponse<Advertisement>
{
    public AdvertisementResponse(string message) : base(message)
    {
    }

    public AdvertisementResponse(Advertisement resource) : base(resource)
    {
    } 
}