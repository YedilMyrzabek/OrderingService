using MassTransit;
using Microsoft.Extensions.Logging;
using Ordering.Application.IntegrationEvents;

namespace Ordering.Application.Consumers;

/// <summary>
/// Consumer для обработки события OrderCreatedEvent
/// </summary>
public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly ILogger<OrderCreatedConsumer> _logger;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var order = context.Message;
        
        _logger.LogInformation(
            "Получено событие OrderCreated: OrderId={OrderId}, Number={Number}, Customer={Customer}, Amount={Amount}", 
            order.OrderId, 
            order.OrderNumber, 
            order.CustomerName, 
            order.TotalAmount);
        
        await Task.CompletedTask;
    }
}