using Shop.Application.Common;
using Shop.Application.Features.Users.Authentication;

namespace Shop.Application.Interfaces;

public interface IUserService
{
    Task<Result> CreateUserAsync(
     string userName,
     string email,
     string password,
     CancellationToken cancellationToken);

    Task<Result<LoginResult>> LoginUserAsync(
      string userNameOrEmail,
      string password,
      CancellationToken cancellationToken);
}
