using AutoMapper;
using GettingBetter.API.Shared.Extensions;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GettingBetter.API.Tournament_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _tournamentService;
    private readonly IMapper _mapper;

    public TournamentsController(ITournamentService tournamentService, IMapper mapper)
    {
        _tournamentService = tournamentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TournamentResource>> GetAllAsync()
    {
        var tournaments = await _tournamentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentResource>>(tournaments);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTournamentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tournament = _mapper.Map<SaveTournamentResource, Tournament>(resource);

        var result = await _tournamentService.SaveAsync(tournament);

        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTournamentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tournament = _mapper.Map<SaveTournamentResource, Tournament>(resource);

        var result = await _tournamentService.UpdateAsync(id, tournament);

        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tournamentService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }
    
}