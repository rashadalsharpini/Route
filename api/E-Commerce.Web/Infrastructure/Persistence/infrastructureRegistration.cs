using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repos;
using StackExchange.Redis;

namespace Persistence;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<StoreDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IDataSeeding, DataSeeding>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBasketRepo, BasketRepo>();
        services.AddSingleton<IConnectionMultiplexer>( _ =>
        {
            return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")!);
        });
        return services;
    }
}