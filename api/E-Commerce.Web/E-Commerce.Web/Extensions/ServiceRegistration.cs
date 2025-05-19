using System.Text;
using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

    public static IServiceCollection AddJWTService(this IServiceCollection services, IConfiguration conf)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = conf["JWTOptions:Issuer"],
                ValidateAudience = true,
                ValidAudience = conf["JWTOptions:Audience"],
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["JWTOptions:SecretKey"]!)),
            };
        });
        return services;
    }
}