using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Services;
using GettingBetter.API.Learning_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Learning_System.Controllers;

[ApiController]
[Route("/api/v1/students/{coachId}/learnings")]
[Produces(MediaTypeNames.Application.Json)]

public class LearningCoachesController : ControllerBase
{
    private readonly ILearningService _learningService;
    private readonly IMapper _mapper;

    public LearningCoachesController(ILearningService learningService, IMapper mapper)
    {
        _learningService = learningService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Learnings for given Coach",
        Description = "Get existing Learning Coaches associated with the specified C",
        OperationId = "GetLearningCoach",
        Tags = new[] { "Coaches" }
    )]
    public async Task<IEnumerable<LearningResource>> GetAllByCoachIdAsync(int coachId)
    {
        var learning = await _learningService.ListByCoachIdAsync(coachId);

        var resources = _mapper.Map<IEnumerable<Learning>, IEnumerable<LearningResource>>(learning);

        return resources;
    }
    
}