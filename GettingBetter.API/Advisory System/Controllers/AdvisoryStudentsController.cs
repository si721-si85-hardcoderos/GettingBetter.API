using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Domain.Services;
using GettingBetter.API.Advisory_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Advisory_System.Controllers;

[ApiController]
[Route("/api/v1/students/{studentId}/advisories")]
[Produces(MediaTypeNames.Application.Json)]
public class AdvisoryStudentsController : ControllerBase
{
    private readonly IAdvisoryService _advisoryService;
    private readonly IMapper _mapper;

    public AdvisoryStudentsController(IAdvisoryService advisoryService, IMapper mapper)
    {
        _advisoryService = advisoryService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Advisories for given Students",
        Description = "Get existing Advisories associated with the specified Students",
        OperationId = "GetStudentAdvisory",
        Tags = new[] { "Students" }
    )]
    public async Task<IEnumerable<AdvisoryResource>> GetAllByCoachIdAsync(int coachId)
    {
        var advisories = await _advisoryService.ListByStudentIdAsync(coachId);

        var resources = _mapper.Map<IEnumerable<Advisory>, IEnumerable<AdvisoryResource>>(advisories);

        return resources;
    } 
}