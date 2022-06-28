using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Services;
using GettingBetter.API.Learning_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Learning_System.Controllers;

[ApiController]
[Route("/api/v1/students/{studentId}/learnings")]
[Produces(MediaTypeNames.Application.Json)]

public class LearningStudentsController : ControllerBase
{
    private readonly ILearningService _learningService;
    private readonly IMapper _mapper;

    public LearningStudentsController(ILearningService learningService, IMapper mapper)
    {
        _learningService = learningService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Learnings for given Student",
        Description = "Get existing Learning Students associated with the specified C",
        OperationId = "GetLearningStudent",
        Tags = new[] { "Students" }
    )]
    public async Task<IEnumerable<LearningResource>> GetAllByStudentIdAsync(int studentId)
    {
        var learning = await _learningService.ListByStudentIdAsync(studentId);

        var resources = _mapper.Map<IEnumerable<Learning>, IEnumerable<LearningResource>>(learning);

        return resources;
    }
    
}