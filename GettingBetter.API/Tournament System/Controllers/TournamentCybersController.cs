using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Tournament_System.Controllers;

[ApiController]
[Route("/api/v1/cybers/{cyberId}/tournaments")]
[Produces(MediaTypeNames.Application.Json)]
public class TournamentCybersController : ControllerBase
{
    private readonly ITournamentService _tournamentService;
    private readonly IMapper _mapper;

    public TournamentCybersController(ITournamentService tournamentService, IMapper mapper)
    {
        _tournamentService = tournamentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Tournaments for given Cybers",
        Description = "Get existing Tournaments associated with the specified Cybers",
        OperationId = "GetCyberTournaments",
        Tags = new[] { "Cybers" }
    )]
    public async Task<IEnumerable<TournamentResource>> GetAllByCategoryIdAsync(int categoryId)
    {
        var tournaments = await _tournamentService.ListByCyberIdAsync(categoryId);

        var resources = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentResource>>(tournaments);

        return resources;
    } 
}