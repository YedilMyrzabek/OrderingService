using Ordering.Domain.Enum;

namespace Ordering.Application.IntegrationEvents;

/// <summary>
/// Событие создания нового заказа
/// </summary>
public record OrderCreatedEvent
{
    public Guid OrderId { get; init; }
    public string OrderNumber { get; init; } = default!;
    public string CustomerName { get; init; } = default!;
    public decimal TotalAmount { get; init; }
    public OrderStatus Status { get; init; }
    public DateTime CreatedAtUtc { get; init; }
}