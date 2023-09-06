namespace Domain.BetsAggregate;

public interface IBetRepository
{
    Task<Bet?> GetBetByIdAsync(Guid id);
    Task SaveBetAsync(Bet bet);
    Task RemoveBetAsync(Bet bet);
    Task<IEnumerable<Bet>> GetAllBetsAsync();
    Task<Bet> PlaceBetAsync(Bet bet);
}