using AutoMapper;
using Domain.Contracts;
using Domain.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;

namespace Service;

public class ServiceManager(IUnitOfWork uow, IMapper mapper, IBasketRepo basketRepo, UserManager<AppUser> userManager):IServiceManager
{
    private readonly Lazy<IProductService> _lazyProductService = new(()=> new ProductService(uow, mapper));
    
    private readonly Lazy<IBasketService> _lazyBasketService = new(()=> new BasketService(basketRepo, mapper));

    private readonly Lazy<IAuthenticationService> _lazyAuthenticationService = new(()=>new AuthenticationService(userManager));
    public IProductService ProductService => _lazyProductService.Value;
    public IBasketService BasketService => _lazyBasketService.Value;
    public IAuthenticationService AuthenticationService => _lazyAuthenticationService.Value;
}