using BusinessLogic.Interfaces;
using BusinessLogic.Profiles;
using BusinessLogic.Service;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repos.Interfaces;
using Repos.Repos;
namespace presentation.mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews(opt =>
        {
            opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        // builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        builder.Services.AddAutoMapper(m=>m.AddProfile(new MappingProfiles()));
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}