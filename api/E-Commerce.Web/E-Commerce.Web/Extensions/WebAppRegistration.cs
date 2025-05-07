using Domain.Contracts;
using E_Commerce.Web.CustomMiddleWares;

namespace E_Commerce.Web.Extensions;

public static class WebAppRegistration
{
    public static async Task SeedDataAsync(this WebApplication app)
    {
        using var scoope = app.Services.CreateScope();
        var objectDataSeeding = scoope.ServiceProvider.GetRequiredService<IDataSeeding>();
        await objectDataSeeding.DataSeedAsync();
    }

    public static IApplicationBuilder useCustomExpectionMiddleWare(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionHandlerMiddleWare>();
        return app;
    }

    public static IApplicationBuilder userSwaggerMiddleware(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}