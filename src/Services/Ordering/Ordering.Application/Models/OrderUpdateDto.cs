using Ordering.Domain.Enum;

namespace Ordering.Application.Models;

public record OrderUpdateDto(
    string CustomerName,
    decimal TotalAmount,
    OrderStatus Status
);