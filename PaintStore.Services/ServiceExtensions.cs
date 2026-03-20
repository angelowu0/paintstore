using Microsoft.Extensions.DependencyInjection;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Interfaces.Services;
using PaintStore.Repositories;
using PaintStore.Services.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceExtensions));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPaintProductService, PaintProductService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaintProductRepository, PaintProductRepository>();
        return services;
    }
}