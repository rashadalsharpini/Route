using AutoMapper;
using Domain.Models;
using Domain.Models.productModule;
using Shared.DTOs;
using Shared.DTOs.productDto;

namespace Service.MappingProfiles;

public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dist => dist.BrandName,
                opt => opt.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dist => dist.TypeName,
                opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dist => dist.PictureUrl,
                opt => opt.MapFrom<PictureUrlResolver>());

        CreateMap<ProductType, TypeDto>();
        CreateMap<ProductBrand, BrandDto>();

    }
}