namespace ConsoleApp1;

public class Order
{
    public int orderId { get; set; }
    public string customerName { get; set; }
    public double orderAmount { get; set; }
    public IOrderProcessor orderProcessor { get; set; }

    public void ProcessOrder()
    {
        orderProcessor.ProcessOrder(this);
    }
}