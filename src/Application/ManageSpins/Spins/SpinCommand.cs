namespace Application.ManageSpins.Spins;

public record SpinCommand() : IRequest<ErrorOr<Guid>>;

public class SpinCommandHandler : IRequestHandler<SpinCommand, ErrorOr<Guid>>
{
    public SpinCommandHandler()
    {
        // Constructor logic
    }

    public async Task<ErrorOr<Guid>> Handle(SpinCommand request, CancellationToken cancellationToken)
    {
        // Logic to handle the SpinCommand command
        

        return new ErrorOr<Guid>();
    }
}
