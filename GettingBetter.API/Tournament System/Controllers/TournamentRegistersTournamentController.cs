using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Tournament_System.Controllers;
[ApiController]
[Route("/api/v1/tournaments/{tournamentId}/registerTournaments")]
[Produces(MediaTypeNames.Application.Json)]
public class TournamentRegistersTournamentController
{
    private readonly IRegisterTournamentService _registerTournamentService;
    private readonly IMapper _mapper;

    public TournamentRegistersTournamentController(IRegisterTournamentService registerTournamentService, IMapper mapper)
    {
        _registerTournamentService = registerTournamentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All RegisterTournament for given Tournament",
        Description = "Get existing RegisterTournaments associated with the specified Tournament",
        OperationId = "GetTournamentRegisterTournaments",
        Tags = new[] {"Tournaments"}
    )]
    public async Task<IEnumerable<RegisterTournamentResource>> GetAllByTournamentIdAsync(int tournamentId)
    {
        var registerTournament = await _registerTournamentService.ListByTournamentIdAsync(tournamentId);

        var resources = _mapper.Map<IEnumerable<RegisterTournament>, IEnumerable<RegisterTournamentResource>>(registerTournament);

        return resources;
    }
}