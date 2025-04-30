using AutoMapper;
using Domain.Contracts;
using ServiceAbstraction;

namespace Service;

public class ServiceManager(IUnitOfWork uow, IMapper mapper):IServiceManager
{
    private readonly Lazy<IProductService> _lazyProductService = new Lazy<IProductService>(()=> new ProductService(uow, mapper));
    public IProductService ProductService => _lazyProductService.Value;
}