namespace Application.ManageSpins.ShowPrevious;

public record ShowPreviousSpinsQuery() : IRequest<ErrorOr<List<ManageSpins.Spin>>>;

public class ShowPreviousSpinsQueryHandler : IRequestHandler<ShowPreviousSpinsQuery, ErrorOr<List<ManageSpins.Spin>>>
{
    public ShowPreviousSpinsQueryHandler()
    {
        // Constructor logic
    }

    public async Task<ErrorOr<List<ManageSpins.Spin>>> Handle(ShowPreviousSpinsQuery request, CancellationToken cancellationToken)
    {
        // Logic to handle the ShowPreviousSpinsQuery command
        

        return new ErrorOr<List<ManageSpins.Spin>>();
    }
}
