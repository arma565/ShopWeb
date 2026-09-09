using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shop.Domain.Entities.Authentications;
using System;
using System.Text;

namespace Shop.Infrastructure.Data.Configurations;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "ShopAppCookie";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.SlidingExpiration = true;
        });

        services.Configure<JWTOptions>(configuration.GetSection("Jwt"));
        services.AddAuthentication().AddJwtBearer(options =>
        {
            var jwt = configuration.GetSection("Jwt").Get<JWTOptions>();

            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwt!.Issuer,
                ValidAudience = jwt!.Audience,

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt!.Secret))
            };
        });

        return services;
    }
}
