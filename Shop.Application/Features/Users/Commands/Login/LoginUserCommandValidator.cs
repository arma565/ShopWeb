using FluentValidation;

namespace Shop.Application.Features.Users.Commands.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {

        RuleFor(loginUserCommand => loginUserCommand.UserNameOrEmail)
            .NotEmpty()
            .WithMessage("UserName or email is required!")
            .MinimumLength(3)
            .WithMessage("UserName or email must be at least 3 characters long!")
            .EmailAddress()
            .WithMessage("Invalid email format!");

        RuleFor(x => x.UserNameOrEmail)
             .EmailAddress()
             .When(x => x.UserNameOrEmail.Contains("@"))
             .WithMessage("Invalid email format!");

        RuleFor(loginUserCommand => loginUserCommand.Password)
            .NotEmpty()
            .WithMessage("Username is required!")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long!");
    }
}
