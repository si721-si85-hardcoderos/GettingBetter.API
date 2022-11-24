using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Shared.Domain.Repositories;
using GettingBetter.API.Event_System.Domain.Models;
using GettingBetter.API.Event_System.Domain.Repositories;
using GettingBetter.API.Event_System.Domain.Services;
using GettingBetter.API.Event_System.Domain.Services.Communication;

namespace GettingBetter.API.Event_System.Services;

public class EventService : IEventService
{ 
   private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICyberRepository _cyberRepository;

    public EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork, ICyberRepository cyberRepository)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
        _cyberRepository = cyberRepository;
    }

    public async Task<IEnumerable<Event>> ListAsync()
    {
        return await _eventRepository.ListAsync();
    }

    public async Task<IEnumerable<Event>> ListByCyberIdAsync(int cyberId)
    {
        return await _eventRepository.FindByCyberIdAsync(cyberId);
    }

    public async Task<EventResponse> SaveAsync(Event evento)
    {
        

        var existingCyber = await _cyberRepository.FindByIdAsync(evento.CyberId);

        if (existingCyber == null)
            return new EventResponse("Invalid Cyber");
        
        // Validate Stuent
        try
        {
            
            await _eventRepository.AddAsync(evento);
            
            
            await _unitOfWork.CompleteAsync();
            
            
            return new EventResponse(evento);

        }
        catch (Exception e)
        {
            // Error Handling
            return new EventResponse($"An error occurred while saving the event: {e.Message}");
        }

        
    }

    public async Task<EventResponse> UpdateAsync(int eventId, Event  evento)
    {
        var existingEvent = await _eventRepository.FindByIdAsync(eventId);
        
 

        if (existingEvent == null)
            return new EventResponse("Event not found.");

        // Validate CyberId

        var existingCyber = await _eventRepository.FindByIdAsync(evento.CyberId);

        if (existingCyber == null)
            return new EventResponse("Invalid Cyber");
        
        // Validate StudentId

       
        
        // Modify Fields
        existingEvent.Title = evento.Title;
        existingEvent.Address = evento.Address;
        existingEvent.UrlPublication = evento.UrlPublication;
        existingEvent.Description = evento.Description;
        existingEvent.ImageEvent = evento.ImageEvent;

        try
        {
            _eventRepository.Update(existingEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(existingEvent);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new EventResponse($"An error occurred while updating the event: {e.Message}");
        }

    }

    public async Task<EventResponse> DeleteAsync(int eventId)
    {
        var existingEvent = await _eventRepository.FindByIdAsync(eventId);
        
        // Validate Tutorial

        if (existingEvent == null)
            return new EventResponse("Event not found.");
        
        try
        {
            _eventRepository.Remove(existingEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(existingEvent);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new EventResponse($"An error occurred while deleting the event: {e.Message}");
        }

    }
}