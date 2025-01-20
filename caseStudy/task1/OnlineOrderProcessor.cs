namespace ConsoleApp1;

public class OnlineOrderProcessor : IOrderProcessor
{
    public void ProcessOrder(Order order)
    { 
        double discountedAmount = CalculateDiscount(order.orderAmount);
        Console.WriteLine($"Order {order.orderId} processed for {order.customerName}. Final amount after 10% discount: ${discountedAmount}");

    }

    public double CalculateDiscount(double orderAmount)
    {
        return orderAmount * 0.9; 
    }
}
