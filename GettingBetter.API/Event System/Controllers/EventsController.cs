using AutoMapper;
using GettingBetter.API.Event_System.Domain.Models;
using GettingBetter.API.Shared.Extensions;
using GettingBetter.API.Event_System.Domain.Services;
using GettingBetter.API.Event_System.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GettingBetter.API.Event_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public EventsController(IEventService eventService, IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<EventResource>> GetAllAsync()
    {
        var events = await _eventService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveEventResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var evento = _mapper.Map<SaveEventResource, Event>(resource);

        var result = await _eventService.SaveAsync(evento);

        if (!result.Success)
            return BadRequest(result.Message);

        var eventResource = _mapper.Map<Event, EventResource>(result.Resource);

        return Ok(eventResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEventResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var evento = _mapper.Map<SaveEventResource, Event>(resource);

        var result = await _eventService.UpdateAsync(id, evento);

        if (!result.Success)
            return BadRequest(result.Message);

        var eventResource = _mapper.Map<Event, EventResource>(result.Resource);

        return Ok(eventResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _eventService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var eventResource = _mapper.Map<Event, EventResource>(result.Resource);

        return Ok(eventResource);
    }
    
}