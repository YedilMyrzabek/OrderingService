using MassTransit;
using Microsoft.Extensions.Logging;
using Ordering.Application.IntegrationEvents;

namespace Ordering.Application.Consumers;

public class OrderEmailConsumer : IConsumer<OrderEmailEvent>
{
    private readonly ILogger<OrderEmailConsumer> _logger;

    public OrderEmailConsumer(ILogger<OrderEmailConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderEmailEvent> context)
    {
        var orderEmail = context.Message;
        
        _logger.LogInformation($"Send Email to: {orderEmail.OrderName}, Order Name: {orderEmail.OrderName}");
        
        await Task.CompletedTask;
    }
}