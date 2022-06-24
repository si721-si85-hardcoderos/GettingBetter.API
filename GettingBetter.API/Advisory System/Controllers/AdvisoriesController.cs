using AutoMapper;
using GettingBetter.API.Shared.Extensions;
using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Domain.Services;
using GettingBetter.API.Advisory_System.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GettingBetter.API.Advisory_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AdvisoriesController : ControllerBase
{
    private readonly IAdvisoryService _advisoryService;
    private readonly IMapper _mapper;

    public AdvisoriesController(IAdvisoryService advisoryService, IMapper mapper)
    {
        _advisoryService = advisoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AdvisoryResource>> GetAllAsync()
    {
        var advisories = await _advisoryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Advisory>, IEnumerable<AdvisoryResource>>(advisories);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAdvisoryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var advisory = _mapper.Map<SaveAdvisoryResource, Advisory>(resource);

        var result = await _advisoryService.SaveAsync(advisory);

        if (!result.Success)
            return BadRequest(result.Message);

        var advisoryResource = _mapper.Map<Advisory, AdvisoryResource>(result.Resource);

        return Ok(advisoryResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdvisoryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var advisory = _mapper.Map<SaveAdvisoryResource, Advisory>(resource);

        var result = await _advisoryService.UpdateAsync(id, advisory);

        if (!result.Success)
            return BadRequest(result.Message);

        var advisoryResource = _mapper.Map<Advisory, AdvisoryResource>(result.Resource);

        return Ok(advisoryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _advisoryService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var advisoryResource = _mapper.Map<Advisory, AdvisoryResource>(result.Resource);

        return Ok(advisoryResource);
    }
    
}