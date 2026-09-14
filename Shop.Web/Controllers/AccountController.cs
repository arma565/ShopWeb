using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Users.Commands.Login;
using Shop.Application.Features.Users.Commands.Logout;
using Shop.Application.Features.Users.Commands.Register;
using Shop.Web.Models.Account;
using System.Security.Claims;

namespace Shop.Web.Controllers;

public class AccountController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserViewModel model)
    {

        if (!ModelState.IsValid)
            return View(model);

        var command = new RegisterUserCommand(
            UserName: model.UserName,
            Email: model.Email,
            Password: model.Password,
            ConfirmedPassword: model.ConfirmedPassword,
            AcceptedTermsAndConditions: model.AcceptedTermsAndConditions
            );

        var result = await _sender.Send(command);

        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.Error!);

            return View(model);
        }

        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, CancellationToken cancellationToken)
    {

        if (!ModelState.IsValid)
            return View(model);

        var command = new LoginUserCommand(model.UserNameOrEmail, model.Password);

        var result = await _sender.Send(command, cancellationToken);

        if (!result.IsSuccess)
        {
            ModelState.AddModelError(
                string.Empty,
                result.Error ?? "Invalid username/email or password!");

            return View(model);
        }

        await SignIn(result.Data!.UserId.ToString(), result.Data!.UserName, model.RememberMe);

        return RedirectToAction(nameof(Index), "/");
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task Logout(CancellationToken cancellationToken)
    {
        await _sender.Send(new LogoutUserCommand(), cancellationToken);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    private async Task SignIn(string userId, string username, bool rememberMe)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier , userId),
            new (ClaimTypes.Name , username)
        };

        var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

        var identity = new ClaimsIdentity(claims, scheme);

        var principal = new ClaimsPrincipal(identity);

        var properties = new AuthenticationProperties
        {
            IsPersistent = rememberMe
        };

        await HttpContext.SignInAsync(
            scheme,
            principal,
            properties);
    }
}
