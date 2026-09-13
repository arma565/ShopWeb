using MediatR;
using Shop.Application.Common;
using Shop.Application.Features.Users.Commands.Register;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Users.CommandsHandler;

public class RegisterUserCommandHandler(IUserService userService) : IRequestHandler<RegisterUserCommand, Result>
{
    private readonly IUserService _userService = userService;
    public async Task<Result> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        return await _userService.CreateUserAsync(
                command.UserName,
                command.Email,
                command.Password,
                cancellationToken
            );
    }
}
