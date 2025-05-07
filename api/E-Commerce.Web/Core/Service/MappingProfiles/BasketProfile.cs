using AutoMapper;
using Domain.Models.BasketModel;
using Shared.DTOs.BasketDto;

namespace Service.MappingProfiles;

public class BasketProfile:Profile
{
    public BasketProfile()
    {
        CreateMap<CustomerBasket, BasketDto>().ReverseMap();
        CreateMap<BasktItem, BasketItemDto>().ReverseMap();
    }
}