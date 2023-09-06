using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RouletteDbContext>(options => 
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        //services.AddDbContext<RouletteDbContext>(options =>
                //options.UseInMemoryDatabase("Roulette"));
        return services;
    }
}