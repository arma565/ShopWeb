using Shop.Application.Common;

namespace Shop.Application.Interfaces;

public interface IUserService
{
    Task<Result> CreateUserAsync(
     string UserName,
     string Email,
     string Password);
}
