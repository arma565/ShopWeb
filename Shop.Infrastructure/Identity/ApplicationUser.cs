using Microsoft.AspNetCore.Identity;

namespace Shop.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool IsDisabled { get; set; }
}
