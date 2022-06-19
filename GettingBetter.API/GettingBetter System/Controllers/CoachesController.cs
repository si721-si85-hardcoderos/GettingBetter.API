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
[SwaggerTag("Create, read, update and delete Coaches")]
public class CoachesController : ControllerBase
{
    private readonly ICoachService _coachService;
    private readonly IMapper _mapper;
    

    public CoachesController(ICoachService coachService, IMapper mapper)
    {
        _coachService = coachService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CoachResource>), 200)]
    public async Task<IEnumerable<CoachResource>> GetAllAsync()
    {
        var coaches = await _coachService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Coach>, IEnumerable<CoachResource>>(coaches);

        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CoachResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerResponse(201, "The coach was successfully created.", typeof(CoachResource))]
    [SwaggerResponse(400, "The coach data is not valid.")]
    public async Task<IActionResult> PostAsync([FromBody] SaveCoachResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var coach = _mapper.Map<SaveCoachResource, Coach>(resource);

        var result = await _coachService.SaveAsync(coach);

        if (!result.Success)
            return BadRequest(result.Message);

        var coachResource = _mapper.Map<Coach, CoachResource>(result.Resource);

        return Created(nameof(PostAsync),coachResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCoachResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var coach = _mapper.Map<SaveCoachResource, Coach>(resource);
        var result = await _coachService.UpdateAsync(id, coach);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var coachResource = _mapper.Map<Coach, CoachResource>(result.Resource);

        return Ok(coachResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _coachService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var coachResource = _mapper.Map<Coach, CoachResource>(result.Resource);

        return Ok(coachResource);
    }
}
