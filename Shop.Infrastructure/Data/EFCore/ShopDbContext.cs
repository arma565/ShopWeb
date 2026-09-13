using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Identity;

namespace Shop.Infrastructure.Data.EFCore;

public class ShopDbContext(DbContextOptions<ShopDbContext> options) : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>(options){}
