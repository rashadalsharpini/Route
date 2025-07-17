using System.Linq.Expressions;
using Domain.Models.OrderModel;

namespace Service.Specifications;

class OrderSpecifications:BaseSpecifications<Order, Guid>
{
    public OrderSpecifications(string email) : base(o => o.BuyerEmail == email)
    {
        AddInclude(o=>o.DeliveryMethod);
        AddInclude(o=>o.Items);
        AddOrderByDes(o=>o.OrderDate);
    }
    public OrderSpecifications(Guid id) : base(o => o.Id == id)
    {
        AddInclude(o=>o.DeliveryMethod);
        AddInclude(o=>o.Items);
    }
}