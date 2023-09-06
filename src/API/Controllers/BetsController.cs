using api.Contracts.Bets;
using Application.ManageBets;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v1/bets")]
public class BetsController: ControllerBase
{
    private readonly ISender _sender;

    public BetsController(ISender sender ) => _sender = sender;

    [HttpPost]
    public async Task<IActionResult> PlaceBet(
            [FromBody] BetRequest request,
            CancellationToken cancellationToken)
    {
        var command = request.Adapt<BetCommand>();
        var response = await _sender.Send(command, cancellationToken);
        
        if(response.Errors.Any())
            return BadRequest(response.Errors);

        return Created("bets/{id}", response);
    }
    
    //PUT api/v1/bets/{id}
    //GET api/v1/bets/{id}
    //DELETE api/v1/bets/{id}
}