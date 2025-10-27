using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Abstractions.Persistence;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        var cs = cfg.GetConnectionString("DefaultConnection");

        services.AddDbContext<OrderingDbContext>(opt =>
            opt.UseNpgsql(cs, npg => npg.MigrationsAssembly(typeof(OrderingDbContext).Assembly.FullName)));

        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}