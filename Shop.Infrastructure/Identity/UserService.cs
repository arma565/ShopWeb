using Microsoft.AspNetCore.Identity;
using Shop.Application.Common;
using Shop.Application.Features.Users.Authentication;
using Shop.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Shop.Infrastructure.Identity;

public class UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private const string InvalidCredentialsMessage = "Invalid username/email or password!";

    public async Task<Result> CreateUserAsync(string userName, string email, string password, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email
        };

        var result = _userManager.CreateAsync(user, password).Result;

        if (result.Succeeded)
            return Result.Success();

        var errors = result.Errors.Select(error => error.Description).ToList();

        return Result.Failure(errors);
    }

    public async Task<Result<LoginResult>> LoginUserAsync(string userNameOrEmail, string password, CancellationToken cancellationToken)
    {
        ApplicationUser? user;

        if (IsEmail(userNameOrEmail))
        {
            user = await _userManager.FindByEmailAsync(userNameOrEmail).ConfigureAwait(false);
        }
        else
        {
            user = await _userManager.FindByNameAsync(userNameOrEmail).ConfigureAwait(false);
        }

        if (user == null)
            return Result<LoginResult>.Failure([InvalidCredentialsMessage]);

        if (user.IsDisabled)
        {
            return Result<LoginResult>.Failure(
            [
                InvalidCredentialsMessage
            ]);
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(
      user,
      password,
      lockoutOnFailure: true);

        if (!signInResult.Succeeded)
        {
            return Result<LoginResult>.Failure(
                [InvalidCredentialsMessage]);
        }

        var loginResult = new LoginResult(
        user.Id,
        user.UserName!);

        return Result<LoginResult>.Success(loginResult);
    }

    private static bool IsEmail(string value) => new EmailAddressAttribute().IsValid(value);

}
