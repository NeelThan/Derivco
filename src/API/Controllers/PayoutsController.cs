using Application.ManagePayouts;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/payouts")]
public class PayoutsController: ControllerBase
{
    private readonly ISender _sender;

    public PayoutsController(ISender sender ) => _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Payout(
        [FromBody] PayoutRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<PayoutCommand>();
        var response = await _sender.Send(command, cancellationToken);
        
        if(response.Errors.Any())
            return BadRequest(response.Errors);

        return Created("bets/{id}", response);
    }
}

public record PayoutRequest();