using FluentValidation;
using Shop.Application.Features.Users.Commands;

namespace Shop.Application.Features.Users.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator() {
        
        RuleFor(registerUserCommand => registerUserCommand.UserName)
            .NotEmpty()
            .WithMessage("Username is required!")
            .MinimumLength(3)
            .WithMessage("Username must be at least 3 characters long!");

        RuleFor(registerUserCommand => registerUserCommand.Email)
            .NotEmpty()
            .WithMessage("Email is required!")
            .EmailAddress()
            .WithMessage("Invalid email format!");

        RuleFor(registerUserCommand => registerUserCommand.Password)
            .NotEmpty()
            .WithMessage("Password is required!")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long!");

        RuleFor(registerUserCommand => registerUserCommand.ConfirmedPassword)
            .Equal(registerUserCommand => registerUserCommand.Password)
            .WithMessage("Passwords do not match!");

        RuleFor(registerUserCommand => registerUserCommand.AcceptedTermsAndConditions)
            .Equal(true)
            .WithMessage("You must accept the terms and conditions!");


    }
}
