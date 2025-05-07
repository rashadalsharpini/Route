using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
    public static IServiceCollection AddWebAppServices(this IServiceCollection services)
    {
        
        services.Configure<ApiBehaviorOptions>(opt =>
        {
            opt.InvalidModelStateResponseFactory = ApiResFactory.GenerateApiValidationErrorResponse;
        });
        return services;
    }
}