namespace Domain.Models.OrderModel;

public enum OrderStatus
{
    Pending = 0,
    PaymentReceived = 1,
    PaymentFailed = 2,
}