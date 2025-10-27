using Ordering.Application.DTOs;

namespace Ordering.Application.Interfaces;

public interface IOrderService
{
    Task<OrderDto.OrderReadDto> CreateAsync(OrderDto.OrderCreateDto dto, CancellationToken ct = default);
    Task<OrderDto.OrderReadDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<OrderDto.OrderReadDto>> GetPagedAsync(int pageIndex, int pageSize, CancellationToken ct);
    Task<OrderDto.OrderReadDto?> UpdateAsync(Guid id, OrderDto.OrderUpdateDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
}