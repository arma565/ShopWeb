using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;
using Shop.Infrastructure.Identity;

namespace Shop.Infrastructure.DependencyInjection;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}
