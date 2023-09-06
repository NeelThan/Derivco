using Application.ManageSpins.ShowPrevious;
using Application.ManageSpins.Spins;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/spins")]
public class SpinsController: ControllerBase
{
    private readonly ISender _sender;

    public SpinsController(ISender sender) => _sender = sender;
    
    [HttpPost]
    public async Task<IActionResult> Spin(
        [FromBody] SpinRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<SpinCommand>();
        var response = await _sender.Send(command, cancellationToken);
        
        if(response.Errors.Any())
            return BadRequest(response.Errors);
        
        return Created("spins/{id}", response);
    }
    
    [HttpGet]
    public async Task<IActionResult> ShowPreviousSpins(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new ShowPreviousSpinsQuery(), cancellationToken);
        
        if(response.Errors.Any())
            return BadRequest(response.Errors);
        
        return Ok(response);
    }
}

public record SpinRequest();