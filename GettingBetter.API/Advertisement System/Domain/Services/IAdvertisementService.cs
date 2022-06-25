using GettingBetter.API.Advertisement_System.Domain.Models;
using GettingBetter.API.Advertisement_System.Domain.Services.Communication;

namespace GettingBetter.API.Advertisement_System.Domain.Services;

public interface IAdvertisementService
{
    Task<IEnumerable<Advertisement>> ListAsync();
}