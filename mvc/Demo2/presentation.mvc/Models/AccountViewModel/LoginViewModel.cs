using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace presentation.mvc.Models.AccountViewModel;

public class LoginViewModel
{
    [EmailAddress]
    public string Email { get; set; } = null!;
    [PasswordPropertyText]
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; }
}