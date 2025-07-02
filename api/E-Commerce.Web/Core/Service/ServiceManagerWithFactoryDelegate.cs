using ServiceAbstraction;

namespace Service;

public class ServiceManagerWithFactoryDelegate(Func<IProductService> productFactory,
    Func<IBasketService> basketFactory,
    Func<IOrderService> orderFactory,
    Func<IAuthenticationService> authenticationFactory):IServiceManager
{
    public IProductService ProductService => productFactory.Invoke();
    public IBasketService BasketService  =>basketFactory.Invoke();
    public IAuthenticationService AuthenticationService  => authenticationFactory.Invoke();
    public IOrderService OrderService => orderFactory.Invoke();
}