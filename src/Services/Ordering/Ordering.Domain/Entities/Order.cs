using Ordering.Domain.Enum;

namespace Ordering.Domain.Entities;

/// <summary>
/// Модуль Order.
/// </summary>
public class Order
{
    /// <summary>
    /// Уникальный идентификатор заказа.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Номер заказа.
    /// </summary>
    public string Number { get; set; } = default!;

    /// <summary>
    /// Имя клиента, оформившего заказ.
    /// </summary>
    public string CustomerName { get; set; } = default!;

    /// <summary>
    /// Общая сумма заказа.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Текущий статус заказа.
    /// </summary>
    public OrderStatus Status { get; set; } = OrderStatus.New;

    /// <summary>
    /// Дата и время создания заказа (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата и время последнего обновления заказа (UTC).
    /// </summary>
    public DateTime? UpdatedAtUtc { get; set; }
}