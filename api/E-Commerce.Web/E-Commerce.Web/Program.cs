using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repos;
using Service;
using ServiceAbstraction;

namespace E_Commerce.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<StoreDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddScoped<IDataSeeding, DataSeeding>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddAutoMapper(typeof(Service.AssemblyRef).Assembly);
        builder.Services.AddScoped<IServiceManager, ServiceManager>();
        
        
        var app = builder.Build();
        
        
        using var scoope = app.Services.CreateScope();
        var objectDataSeeding= scoope.ServiceProvider.GetRequiredService<IDataSeeding>();
        await objectDataSeeding.DataSeedAsync();
        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();



        app.MapControllers();

        app.Run();
    }
}