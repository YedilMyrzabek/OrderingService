namespace Ordering.Application.IntegrationEvents;

public record OrderEmailEvent
{
    public string OrderName { get; set; } = default;
    public string CustomerName { get; set; } = default;
}