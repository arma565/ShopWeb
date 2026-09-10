using Shop.Application.Interfaces;
using Shop.Domain.Entities.Users;

namespace Shop.Infrastructure.Data.Dapper;

public class UserRepository : IUserRepository
{
    public Task<ApplicationUser> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task RegisterUser(ApplicationUser user)
    {
        throw new NotImplementedException();
    }
}
