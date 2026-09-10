using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Users;

namespace Shop.Infrastructure.Data.EFCore;

internal class ShopDbContext(DbContextOptions<ShopDbContext> options) : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>(options){}
