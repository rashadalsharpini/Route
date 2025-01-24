IAuthenticationService AS = new BasicAuthenticationService();
Console.WriteLine(AS.AuthenticateUser("admin", "admin") ? "Welcome Admin" : "wrong Authentication");
Console.WriteLine(AS.AuthenticateUser("rashad", "not admin") ? "Welcome Admin" : "wrong Authentication");

public interface IAuthenticationService
{
    public bool AuthenticateUser(string username, string password);
    public bool AuthorizeUser(string username, string password);
}

public class authorizedUser
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public class BasicAuthenticationService : IAuthenticationService
{
    private authorizedUser[] users = new authorizedUser[3];
    public BasicAuthenticationService()
    {
        users[0] = new authorizedUser { Username = "admin", Password = "admin" };
        users[1] = new authorizedUser { Username = "user2", Password = "pass2" };
        users[2] = new authorizedUser { Username = "user3", Password = "pass3" };
    }
    public bool AuthenticateUser(string username, string password)
    {
        foreach (authorizedUser user in users)
        {
            if (user.Username == username && user.Password == password)
                return true;
        } 
        return false;
    }

    public bool AuthorizeUser(string username, string password)
    {
        return AuthenticateUser(username, password);
    }
}

