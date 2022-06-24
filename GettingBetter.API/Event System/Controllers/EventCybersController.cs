using System.Net.Mime;
using AutoMapper;
using GettingBetter.API.Event_System.Domain.Models;
using GettingBetter.API.Event_System.Domain.Services;
using GettingBetter.API.Event_System.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.Event_System.Controllers;

[ApiController]
[Route("/api/v1/cybers/{cyberId}/events")]
[Produces(MediaTypeNames.Application.Json)]
public class EventCybersController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public EventCybersController(IEventService eventService, IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Events for given Cybers",
        Description = "Get existing Events associated with the specified Cybers",
        OperationId = "GetCyberEvents",
        Tags = new[] { "Cybers" }
    )]
    public async Task<IEnumerable<EventResource>> GetAllByCategoryIdAsync(int categoryId)
    {
        var events = await _eventService.ListByCyberIdAsync(categoryId);

        var resources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);

        return resources;
    } 
}