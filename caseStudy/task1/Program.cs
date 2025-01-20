using ConsoleApp1;
Console.WriteLine("Enter Order ID:");
int orderId = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter Customer Name:");
string customerName = Console.ReadLine();

Console.WriteLine("Enter Order Amount:");
double orderAmount = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter Order Type (Online/InStore):");
string orderType = Console.ReadLine().ToLower();

Order order = new Order
{
    orderId = orderId,
    customerName = customerName,
    orderAmount = (double)orderAmount
};

if (orderType == "online")
{
    order.orderProcessor = new OnlineOrderProcessor();
}
else if (orderType == "instore")
{
    order.orderProcessor = new InStoreOrderProcessor();
}
else
{
    Console.WriteLine("Invalid order type. Please specify 'Online' or 'InStore'.");
    return;
}
order.ProcessOrder();
