using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;

namespace Service;

public static class AppServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AssemblyRef).Assembly);
        services.AddScoped<IServiceManager, ServiceManager>();
        return services;
    }
}