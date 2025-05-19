using AutoMapper;
using Domain.Models.IdentityModel;
using Shared.DTOs.IdentityDtos;

namespace Service.MappingProfiles;

public class IdentityProfile:Profile
{
    public IdentityProfile()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}