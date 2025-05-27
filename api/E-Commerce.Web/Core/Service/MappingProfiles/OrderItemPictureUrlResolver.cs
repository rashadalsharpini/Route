using AutoMapper;
using Domain.Models.OrderModel;
using Microsoft.Extensions.Configuration;
using Shared.DTOs.OrderDtos;

namespace Service.MappingProfiles;

public class OrderItemPictureUrlResolver:IValueResolver<OrderItem, OrderItemDto, string>
{
    private readonly IConfiguration _conf;
    public OrderItemPictureUrlResolver(IConfiguration conf)
    {
        _conf = conf;
    }
    public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.Product.PictureUrl))
            return string.Empty;
        var url = $"{_conf.GetSection("Urls")["BaseUrl"]}{source.Product.PictureUrl}";
        return url;
    }
}