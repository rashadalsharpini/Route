using System.Linq.Expressions;
using Domain.Models.OrderModel;

namespace Service.Specifications;

public class OrderWithPaymentIntentIdSpecifications : BaseSpecifications<Order, Guid>
{
    public OrderWithPaymentIntentIdSpecifications(string paymentIntentId) : base(o =>
        o.PaymentIntentId == paymentIntentId)
    {
    }
}