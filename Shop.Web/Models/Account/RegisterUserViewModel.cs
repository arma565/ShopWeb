using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.Account;

public class RegisterUserViewModel
{
    [Required(ErrorMessage = "Username is required!")]
    [MinLength(3, ErrorMessage = "The username must be more than 2 characters!")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress(ErrorMessage = "Invalid email address!")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The password must be more than 8 characters!")]
    public required string Password { get; set; }

    [Compare(nameof(Password),
        ErrorMessage = "Passwords do not match!")]
    public required string ConfirmedPassword { get; set; }

    [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions!")]
    public bool AcceptedTermsAndConditions { get; set; }
}
