using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Domain.Services;
using GettingBetter.API.Advisory_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Advisory_System.Controllers;

[ApiController]
[Route("/api/v1/coaches/{coachId}/advisories")]
[Produces(MediaTypeNames.Application.Json)]
public class AdvisoryCoachesController : ControllerBase
{
    private readonly IAdvisoryService _advisoryService;
    private readonly IMapper _mapper;

    public AdvisoryCoachesController(IAdvisoryService advisoryService, IMapper mapper)
    {
        _advisoryService = advisoryService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Advisories for given Coaches",
        Description = "Get existing Advisories associated with the specified Coaches",
        OperationId = "GetCoachAdvisory",
        Tags = new[] { "Coaches" }
    )]
    public async Task<IEnumerable<AdvisoryResource>> GetAllByStudentIdAsync(int studentId)
    {
        var advisories = await _advisoryService.ListByCoachIdAsync(studentId);

        var resources = _mapper.Map<IEnumerable<Advisory>, IEnumerable<AdvisoryResource>>(advisories);

        return resources;
    } 
}