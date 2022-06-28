using AutoMapper;
using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Domain.Services;
using GettingBetter.API.Learning_System.Resources;
using GettingBetter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GettingBetter.API.Learning_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class LearningController : ControllerBase
{
    private readonly ILearningService _learningService;
    private readonly IMapper _mapper;
    
    public LearningController(ILearningService learningService, IMapper mapper)
    {
        _learningService = learningService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<LearningResource>> GetAllAsync()
    {
        var learnings = await _learningService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Learning>, IEnumerable<LearningResource>>(learnings);

        return resources;

    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveLearningResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var learning = _mapper.Map<SaveLearningResource, Learning>(resource);

        var result = await _learningService.SaveAsync(learning);

        if (!result.Success)
            return BadRequest(result.Message);

        var learningResource = _mapper.Map<Learning, LearningResource>(result.Resource);

        return Ok(learningResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLearningResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var learning = _mapper.Map<SaveLearningResource, Learning>(resource);

        var result = await _learningService.UpdateAsync(id, learning);

        if (!result.Success)
            return BadRequest(result.Message);

        var learningResource = _mapper.Map<Learning, LearningResource>(result.Resource);

        return Ok(learningResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _learningService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var learningResource = _mapper.Map<Learning, LearningResource>(result.Resource);

        return Ok(learningResource);
    }
    
    
}