using MediatR;
using Shop.Application.Common;
using Shop.Application.Features.Users.Authentication;

namespace Shop.Application.Features.Users.Commands.Login;

public record LoginUserCommand(
        string UserNameOrEmail,
        string Password
    ) : IRequest<Result<LoginResult>>;



