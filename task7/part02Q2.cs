IAuthenticationService AS = new BasicAuthenticationService();
Console.WriteLine(AS.AuthenticateUser("admin", "admin") ? "Welcome Admin" : "wrong Authentication");
Console.WriteLine(AS.AuthenticateUser("rashad", "not admin") ? "Welcome Admin" : "wrong Authentication");

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