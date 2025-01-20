namespace ConsoleApp1;

public interface IOrderProcessor
{
    void ProcessOrder(Order order);
    double CalculateDiscount(double orderAmount);
}