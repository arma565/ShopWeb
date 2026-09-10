using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.Users;

public class RegisterUserViewModel
{
    [DefaultValue("")]
    [Required(ErrorMessage = "Username is required!")]
    public required string? UserName { get; set; }

    [DefaultValue("")]
    [Required(ErrorMessage = "Email is required!")]
    public required string? Email { get; set; }

    [DefaultValue("")]
    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The password must be more than 8 characters!")]
    public required string? Password { get; set; }

    [DefaultValue("")]
    [Required(ErrorMessage = "Confirmed Password is required!")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The confirmed password must be more than 8 characters!")]
    public required string? ConfirmedPassword { get; set; }

    [DefaultValue(true)]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions!")]
    public bool AcceptedTermsAndConditions { get; set; }
}
