using Microsoft.Extensions.DependencyInjection;
using Shop.Application;
using Shop.Application.Features.Users.CommandsHandler;

namespace Shop.Infrastructure.Configurations;

public static class MediatRConfiguration
{
    public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services) {

        services.AddMediatR(cfg => {

            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
        
        });

        return services;
        
    }
}
