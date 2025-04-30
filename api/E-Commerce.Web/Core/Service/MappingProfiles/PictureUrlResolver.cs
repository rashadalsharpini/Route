using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Shared.DTOs;

namespace Service.MappingProfiles;

internal class PictureUrlResolver(IConfiguration configuration):IValueResolver<Product, ProductDto, string>
{
    public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.PictureUrl))
            return string.Empty;
        var url = $"{configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
        return url;
    }
}