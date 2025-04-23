using System.ComponentModel.DataAnnotations;

namespace presentation.mvc.Models.AccountViewModel;

public class RegisterViewModel
{
    [Required(ErrorMessage = "FirstName is required")]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(50)]
    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; } = null!;
    [MaxLength(50)]
    [Required(ErrorMessage = "UserName is required")]
    public string UserName { get; set; } = null!;
    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
    public bool IsAgreed { get; set; }
}