INotificationService notify1 = new EmailService();
INotificationService notify2 = new SmsService();
INotificationService notify3 = new PushService();
notify1.SendNotification("user@example.com", "Hello, this is an email notification!");
notify2.SendNotification("1234567890", "Hello, this is an SMS notification!");
notify3.SendNotification("device123", "Hello, this is a push notification!");

public interface INotificationService
{
    void SendNotification(string recipient, string message);
}

public class EmailService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine("Sending notification to " + recipient);
        Console.WriteLine($"message{message}");
    }
}

public class SmsService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine("Sending notification to " + recipient);
        Console.WriteLine($"message{message}");
    }
}

public class PushService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine("Sending notification to " + recipient);
        Console.WriteLine($"message{message}");
    }
}