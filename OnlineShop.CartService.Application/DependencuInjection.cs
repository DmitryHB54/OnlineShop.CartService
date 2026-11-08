using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.CartService.Application.Common.Behaviors;
using System.Reflection;

namespace OnlineShop.CartService.Application;

public static class DependencuInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(cfg => { }, assembly);

        return services;
    }
}