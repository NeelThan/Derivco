using Domain.BetsAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class RouletteDbContext: DbContext
{
    public RouletteDbContext(DbContextOptions<RouletteDbContext> options) : base(options) { }
    
    public DbSet<Bet?> Bets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RouletteDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}