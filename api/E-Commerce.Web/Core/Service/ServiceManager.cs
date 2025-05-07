using AutoMapper;
using Domain.Contracts;
using ServiceAbstraction;

namespace Service;

public class ServiceManager(IUnitOfWork uow, IMapper mapper, IBasketRepo basketRepo):IServiceManager
{
    private readonly Lazy<IProductService> _lazyProductService = new Lazy<IProductService>(()=> new ProductService(uow, mapper));
    public IProductService ProductService => _lazyProductService.Value;
    private readonly Lazy<IBasketService> _lazyBasketService = new Lazy<IBasketService>(()=> new BasketService(basketRepo, mapper));
    public IBasketService BasketService => _lazyBasketService.Value; 
}