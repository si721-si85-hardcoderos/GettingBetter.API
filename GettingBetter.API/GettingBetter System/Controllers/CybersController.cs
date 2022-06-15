using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Services;
using GettingBetter.API.GettingBetter_System.Resources;
using GettingBetter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.GettingBetter_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Cybers")]
public class CybersController : ControllerBase
{
   private readonly ICyberService _cyberService;
    private readonly IMapper _mapper;

    public CybersController(ICyberService cyberService, IMapper mapper)
    {
        _cyberService = cyberService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CyberResource>> GetAllAsync()
    {
        var cybers = await _cyberService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Cyber>, IEnumerable<CyberResource>>(cybers);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCyberResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var cyber = _mapper.Map<SaveCyberResource, Cyber>(resource);

        var result = await _cyberService.SaveAsync(cyber);

        if (!result.Success)
            return BadRequest(result.Message);

        var cyberResource = _mapper.Map<Cyber, CyberResource>(result.Resource);

        return Ok(cyberResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCyberResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var cyber = _mapper.Map<SaveCyberResource, Cyber>(resource);

        var result = await _cyberService.UpdateAsync(id, cyber);

        if (!result.Success)
            return BadRequest(result.Message);

        var cyberResource = _mapper.Map<Cyber, CyberResource>(result.Resource);

        return Ok(cyberResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _cyberService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var cyberResource = _mapper.Map<Cyber, CyberResource>(result.Resource);

        return Ok(cyberResource);
    }
   
}