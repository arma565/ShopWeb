using MediatR;
using Shop.Application.Common;
using Shop.Application.Features.Users.Authentication;
using Shop.Application.Features.Users.Commands.Login;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Users.CommandsHandler;

public class LoginUserCommandHandler(IUserService userService) : IRequestHandler<LoginUserCommand, Result<LoginResult>>
{
    private readonly IUserService _userService = userService;
    public async Task<Result<LoginResult>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
       return await _userService.LoginUserAsync(
            request.UserNameOrEmail,
            request.Password,
            cancellationToken);
    }
}
