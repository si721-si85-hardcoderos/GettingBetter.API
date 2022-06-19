using AutoMapper;
using GettingBetter.API.Shared.Extensions;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GettingBetter.API.Tournament_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RegisterTournamentsController : ControllerBase
{
    private readonly IRegisterTournamentService _registerTournamentService;
    private readonly IMapper _mapper;

    public RegisterTournamentsController(IRegisterTournamentService registerTournamentService, IMapper mapper)
    {
        _registerTournamentService = registerTournamentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RegisterTournamentResource>> GetAllAsync()
    {
        var registerTournaments = await _registerTournamentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<RegisterTournament>, IEnumerable<RegisterTournamentResource>>(registerTournaments);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRegisterTournamentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var registerTournament = _mapper.Map<SaveRegisterTournamentResource, RegisterTournament>(resource);

        var result = await _registerTournamentService.SaveAsync(registerTournament);

        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<RegisterTournament, RegisterTournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRegisterTournamentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var registerTournament = _mapper.Map<SaveRegisterTournamentResource, RegisterTournament>(resource);

        var result = await _registerTournamentService.UpdateAsync(id, registerTournament);

        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<RegisterTournament, RegisterTournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _registerTournamentService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<RegisterTournament, RegisterTournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }
    
}