using Ordering.Domain.Enum;

namespace Ordering.Application.Models;

public record OrderReadDto(
    Guid Id,
    string Number,
    string CustomerName,
    decimal TotalAmount,
    OrderStatus Status,
    DateTime CreatedAtUtc
);