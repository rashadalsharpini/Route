using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;

namespace Service;

public static class AppServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AssemblyRef).Assembly);
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<Func<IProductService>>(provider=>
            ()=> provider.GetRequiredService<IProductService>());
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<Func<IOrderService>>(provider=>
            ()=> provider.GetRequiredService<IOrderService>());
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<Func<IAuthenticationService>>(provider=>
            ()=> provider.GetRequiredService<IAuthenticationService>());
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<Func<IBasketService>>(provider=>
            ()=> provider.GetRequiredService<IBasketService>());
        
        services.AddScoped<ICacheService, CacheService>();
        
        services.AddScoped<IPaymentService, PaymentServicea>();
        services.AddScoped<Func<IPaymentService>>(provider=>
            ()=> provider.GetRequiredService<IPaymentService>());
        return services;
    }
}