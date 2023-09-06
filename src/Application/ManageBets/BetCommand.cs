using Domain.BetsAggregate;

namespace Application.ManageBets;

public record BetCommand(string PlayerName, int BetAmount, int BetNumber) : IRequest<ErrorOr<Guid>>;

public class BetCommandHandler : IRequestHandler<BetCommand, ErrorOr<Guid>>
{
    private readonly IBetRepository _betRepository;

    public BetCommandHandler(IBetRepository betRepository)
    {
        _betRepository = betRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(
            BetCommand request, 
            CancellationToken cancellationToken)
    {
        // Logic to handle the BetCommand command

        return Guid.NewGuid();
    }
}
