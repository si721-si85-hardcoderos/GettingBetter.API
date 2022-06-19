using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Tournament_System.Controllers;
[ApiController]
[Route("/api/v1/students/{studentId}/registerTournaments")]
[Produces(MediaTypeNames.Application.Json)]
public class StudentsRegistersTournamentController : ControllerBase
{
    private readonly IRegisterTournamentService _registerTournamentService;
    private readonly IMapper _mapper;

    public StudentsRegistersTournamentController(IRegisterTournamentService registerTournamentService, IMapper mapper)
    {
        _registerTournamentService = registerTournamentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Registered of Tournaments for given Student",
        Description = "Get existing Registered of Tournaments associated with the specified C",
        OperationId = "GetRegisterStudent",
        Tags = new[] { "Students" }
    )]
    public async Task<IEnumerable<RegisterTournamentResource>> GetAllByStudentIdAsync(int studentId)
    {
        var registerTournament = await _registerTournamentService.ListByStudentIdAsync(studentId);

        var resources = _mapper.Map<IEnumerable<RegisterTournament>, IEnumerable<RegisterTournamentResource>>(registerTournament);

        return resources;
    }
}
