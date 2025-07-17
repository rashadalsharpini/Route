using E_Commerce.Web.Extensions;
using Persistence;
using Service;

namespace E_Commerce.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });
        });
        
        builder.Services.AddSwaggerService();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddAppServices();
        builder.Services.AddWebAppServices();
        builder.Services.AddJWTService(builder.Configuration);
        
        var app = builder.Build();


        await app.SeedDataAsync();

        // Configure the HTTP request pipeline.
        app.useCustomExpectionMiddleWare();
        
        if (app.Environment.IsDevelopment())
        {
            app.userSwaggerMiddleware();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}