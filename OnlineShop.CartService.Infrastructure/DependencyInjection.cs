using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.CartService.Infrastructure.Persistence;

namespace OnlineShop.CartService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrucutre(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CartDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("Default")));

        return services;
    }
}