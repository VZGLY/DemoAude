using System.ComponentModel.DataAnnotations;

namespace DemoAude___Domain.ViewModel;

public class UserLoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}