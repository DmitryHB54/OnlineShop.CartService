
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.CartService.Application.Interface;
using OnlineShop.CartService.Infrastructure.Persistence;
using OnlineShop.CartService.Infrastructure.Services;

namespace OnlineShop.CartService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrucutre(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CartDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("Default")));

        services.AddHttpClient<ICatalogServiceClient, CatalogServiceClient>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetValue<string>("URIs:CatalogService")!);
        });

        return services;
    }
}