namespace ConsoleApp1;

public class InStoreOrderProcessor : IOrderProcessor
{
    public void ProcessOrder(Order order)
    {
        double discountAmount = CalculateDiscount(order.orderAmount);
        Console.WriteLine($"Order {order.orderId} processed for {order.customerName}. Final amount after 5% discount: ${discountAmount}");
    }

    public double CalculateDiscount(double orderAmount)
    {
        return orderAmount * 0.95;
    }
}