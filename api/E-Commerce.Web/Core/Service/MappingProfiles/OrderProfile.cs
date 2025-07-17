using AutoMapper;
using Domain.Models.OrderModel;
using Shared.DTOs.IdentityDtos;
using Shared.DTOs.OrderDtos;

namespace Service.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<AddressDto, OrderAddress>().ReverseMap();
        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
            .ForMember(d => d.OrderItems, opt => opt.MapFrom(src => src.Items))
            .ForMember(d => d.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(d => d.shipToAddress, opt => opt.MapFrom(src => src.ShipToAddress));
        // CreateMap<Order, OrderToReturnDto>()
        //     .ForMember(d => d.DeliveryMethod, opt => opt.MapFrom(d => d.DeliveryMethod.ShortName));
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.ProductName))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemPictureUrlResolver>());
        CreateMap<DeliveryMethod, DeliveryMethodDto>();
    }
}