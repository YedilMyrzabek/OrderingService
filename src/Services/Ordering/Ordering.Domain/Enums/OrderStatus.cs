namespace Ordering.Domain.Enum;

/// <summary>
/// Модуль Order.
/// </summary>
/// <summary>
/// Перечисление, представляющее статус заказа.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Новый заказ.
    /// </summary>
    New = 0,

    /// <summary>
    /// Заказ находится в обработке.
    /// </summary>
    Processing = 1,

    /// <summary>
    /// Заказ выполнен.
    /// </summary>
    Completed = 2,

    /// <summary>
    /// Заказ отменён.
    /// </summary>
    Cancelled = 3
}