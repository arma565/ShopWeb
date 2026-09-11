using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Users.Commands;
using Shop.Controllers;
using Shop.Web.Models.Account;

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

        if (!result.IsSuccess) {
            ModelState.AddModelError(string.Empty, result.Error!);

            return View(model);
        }

        //return RedirectToAction(nameof(Login));
        return RedirectToAction(nameof(Index),nameof(HomeController));
    }
}
