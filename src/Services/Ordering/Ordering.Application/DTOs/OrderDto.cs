using Ordering.Domain.Enum;

namespace Ordering.Application.DTOs;

public class OrderDto
{
    public record OrderCreateDto(string Number, string CustomerName, decimal TotalAmount);
    public record OrderUpdateDto(string CustomerName, decimal TotalAmount, OrderStatus Status);
    public record OrderReadDto(
        Guid Id, 
        string Number, 
        string CustomerName, 
        decimal TotalAmount, 
        OrderStatus Status, 
        DateTime CreatedAtUtc);
}