using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username or email is required!")]
    [MinLength(3, ErrorMessage = "Username or email must be at least 3 characters!")]
    public required string UserNameOrEmail { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters!")]
    public required string Password { get; set; }

    public bool RememberMe { get; set; }
}
