using Microsoft.AspNetCore.Identity;

namespace Shop.Infrastructure.Identity;

internal class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
