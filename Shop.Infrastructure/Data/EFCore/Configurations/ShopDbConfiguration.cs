using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Infrastructure.Data.EFCore.Configurations;

public static class ShopDbConfiguration
{
    public static IServiceCollection AddShopDbConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("ShopDbConnection") ?? throw new ArgumentNullException("ShopDbConnection");

        services.AddDbContext<ShopDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
