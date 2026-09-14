using MediatR;
using Shop.Application.Features.Users.Commands.Logout;
using Shop.Application.Interfaces;

namespace Shop.Application.Features.Users.CommandsHandler;

public class LogoutUserCommandHandler(IUserService userService) : IRequestHandler<LogoutUserCommand>
{
    private readonly IUserService _userService = userService;
    public async Task Handle(LogoutUserCommand _, CancellationToken cancellationToken) 
        => await _userService.LogoutUserAsync(cancellationToken);
    
}
