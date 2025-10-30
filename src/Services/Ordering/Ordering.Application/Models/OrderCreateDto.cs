namespace Ordering.Application.Models;

public record OrderCreateDto(
    string Number,
    string CustomerName,
    decimal TotalAmount
);