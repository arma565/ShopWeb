using Shop.Domain.Entities.Users;

namespace Shop.Application.Interfaces;

public interface IUserRepository
{
    public Task<ApplicationUser> GetUserById(Guid id);

    public Task RegisterUser(ApplicationUser user);
}
