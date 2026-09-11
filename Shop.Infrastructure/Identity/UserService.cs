using Microsoft.AspNetCore.Identity;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities.Users;

namespace Shop.Infrastructure.Identity;

public class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    public async Task<Result> CreateUserAsync(string UserName, string Email, string Password)
    {
        var user = new ApplicationUser
        {
            UserName = UserName,
            Email = Email
        };

        var result = _userManager.CreateAsync(user, Password).Result;
        
        if(result.Succeeded)
        {
            return Result.Success();
        }

        var errors = result.Errors.Select(error => error.Description).ToList();

        return Result.Failure(errors);
    }
}
