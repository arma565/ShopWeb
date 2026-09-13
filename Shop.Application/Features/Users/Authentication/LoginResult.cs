namespace Shop.Application.Features.Users.Authentication;

public sealed record LoginResult(
    Guid UserId,
    string UserName
);
