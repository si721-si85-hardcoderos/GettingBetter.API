/*using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Services;
using GettingBetter.API.GettingBetter_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.GettingBetter_System.Controllers;

[ApiController]
[Route("/api/v1/coaches/{coachId}/students")]
[Produces(MediaTypeNames.Application.Json)]

public class CoachStudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;

    public CoachStudentsController(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Students for given Coach",
        Description = "Get existing Students associated with the specified Coach",
        OperationId = "GetCoachStudents",
        Tags = new[] { "Coaches" }
    )]
    public async Task<IEnumerable<StudentResource>> GetAllByCoachIdAsync(int coachId)
    {
        var students = await _studentService.ListByCoachIdAsync(coachId);

        var resources = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);

        return resources;
    }
}*/