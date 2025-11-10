using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Consumers; 

namespace Ordering.Infrastructure.Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransitWithRabbitMq(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            
            busConfigurator.AddConsumer<OrderCreatedConsumer>();
            busConfigurator.AddConsumer<OrderEmailConsumer>();
            
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(
                    configuration["RabbitMQ:Host"],
                    configuration["RabbitMQ:VirtualHost"],
                    h =>
                    {
                        h.Username(configuration["RabbitMQ:Username"]);
                        h.Password(configuration["RabbitMQ:Password"]);
                    });
                
                configurator.ReceiveEndpoint("order-created-queue", e =>
                {
                    e.ConfigureConsumer<OrderCreatedConsumer>(context);
                });
                
                configurator.ReceiveEndpoint("email-notification-queue", e =>
                {
                    e.ConfigureConsumer<OrderEmailConsumer>(context);
                });
                
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}