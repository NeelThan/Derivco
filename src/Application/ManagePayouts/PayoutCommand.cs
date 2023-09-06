namespace Application.ManagePayouts;

public record PayoutCommand() : IRequest<ErrorOr<Guid>>;

public class PayoutCommandHandler : IRequestHandler<PayoutCommand, ErrorOr<Guid>>
{
    public PayoutCommandHandler()
    {
        // Constructor logic
    }

    public async Task<ErrorOr<Guid>> Handle(PayoutCommand request, CancellationToken cancellationToken)
    {
        // Logic to handle the PayoutCommand command
        

        return new ErrorOr<Guid>();
    }
}
