using System.ComponentModel.DataAnnotations;

namespace DemoAude___Domain.ViewModel;

public class UserRegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }


    
}