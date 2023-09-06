using Domain.BetsAggregate;

namespace Infrastructure.Persistence;

public class BetRepository: IBetRepository
{
    private readonly RouletteDbContext _context;

    public BetRepository(RouletteDbContext context)
        => _context = context;

    public async Task<Bet?> GetBetByIdAsync(Guid id)
        => await _context.Bets.FindAsync(id);

    public async Task SaveBetAsync(Bet bet)
        => await _context.SaveChangesAsync();

    public async Task RemoveBetAsync(Bet bet)
        => throw new NotImplementedException();

    public async Task<IEnumerable<Bet>> GetAllBetsAsync()
        => throw new NotImplementedException();

    public async Task<Bet> PlaceBetAsync(Bet bet)
        => throw new NotImplementedException();
}