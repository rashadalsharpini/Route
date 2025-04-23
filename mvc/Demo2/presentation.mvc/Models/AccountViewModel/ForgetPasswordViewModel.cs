using System.ComponentModel.DataAnnotations;

namespace presentation.mvc.Models.AccountViewModel;

public class ForgetPasswordViewModel
{
    [EmailAddress]
    [Required(ErrorMessage = "email is required")]
    public string Email { get; set; } = null!;
}