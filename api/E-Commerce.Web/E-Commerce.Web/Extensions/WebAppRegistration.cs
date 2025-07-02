using System.Text.Json;
using Domain.Contracts;
using E_Commerce.Web.CustomMiddleWares;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace E_Commerce.Web.Extensions;

public static class WebAppRegistration
{
    public static async Task<WebApplication> SeedDataAsync(this WebApplication app)
    {
        using var scoope = app.Services.CreateScope();
        var objectDataSeeding = scoope.ServiceProvider.GetRequiredService<IDataSeeding>();
        await objectDataSeeding.DataSeedAsync();
        await objectDataSeeding.IdentityDataSeedAsync();
        return app;
    }

    public static IApplicationBuilder useCustomExpectionMiddleWare(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionHandlerMiddleWare>();
        return app;
    }

    public static IApplicationBuilder userSwaggerMiddleware(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(opt =>
        {
            opt.ConfigObject = new ConfigObject()
            {
               DisplayRequestDuration = true
            };
            opt.DocumentTitle = "E-Commerce API";
            opt.JsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            opt.DocExpansion(DocExpansion.None);
            opt.EnableFilter();
            opt.EnablePersistAuthorization();
        });
        return app;
    }
}