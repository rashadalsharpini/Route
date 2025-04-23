using System.ComponentModel.DataAnnotations;

namespace presentation.mvc.Models;

public class ResetPasswordViewModel
{
    [Required, DataType(DataType.Password) ]
    public string Password { get; set; } = null!;
    [Required, DataType(DataType.Password),Compare(nameof(Password)) ]
    public string ConfirmPassword { get; set; } = null!;
}