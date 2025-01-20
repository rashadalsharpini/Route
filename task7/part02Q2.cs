IAuthenticationService AS = new BasicAuthenticationService();
Console.WriteLine(AS.AuthenticateUser("admin", "admin") ? "Welcome Admin" : "Fuck You");
Console.WriteLine(AS.AuthenticateUser("rashad", "WTF") ? "Welcome Admin" : "Fuck You");

public interface IAuthenticationService
{
    public bool AuthenticateUser(string username, string password);
    public bool AuthorizeUser(string username, string password);
}

public class BasicAuthenticationService : IAuthenticationService
{
    private string username = "admin";
    private string password = "admin";
    public bool AuthenticateUser(string username, string password)
    {
        return username == this.username && password == this.password;  
    }

    public bool AuthorizeUser(string username, string password)
    {
        return username == this.username && password == this.password;
    }
}
// to be honest i didn't understand this question 