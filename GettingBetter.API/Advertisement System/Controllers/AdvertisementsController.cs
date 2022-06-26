using AutoMapper;
using GettingBetter.API.Shared.Extensions;
using GettingBetter.API.Advertisement_System.Domain.Models;
using GettingBetter.API.Advertisement_System.Domain.Services;
using GettingBetter.API.Advertisement_System.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GettingBetter.API.Advertisement_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AdvertisementsController : ControllerBase
{
    private readonly IAdvertisementService _advertisementService;
    private readonly IMapper _mapper;

    public AdvertisementsController(IAdvertisementService advertisementService, IMapper mapper)
    {
        _advertisementService = advertisementService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AdvertisementResource>> GetAllAsync()
    {
        var advertisement = await _advertisementService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Advertisement>, IEnumerable<AdvertisementResource>>(advertisements);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAdvertisementResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var advertisement = _mapper.Map<SaveAdvertisementResource, Advertisement>(resource);

        var result = await _advertisementService.SaveAsync(advertisement);

        if (!result.Success)
            return BadRequest(result.Message);

        var advertisementResource = _mapper.Map<Advertisement, AdvertisementResource>(result.Resource);

        return Ok(advertisementResource);
    }
    
}