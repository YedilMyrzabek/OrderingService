using Ordering.Domain.Entities;

namespace Ordering.Application.Abstractions.Persistence;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Order?> GetByNumberAsync(string number, CancellationToken ct = default);
    Task<List<Order>> GetPagedAsync(int pageIndex = 1, int pageSize = 10, CancellationToken ct = default);
    Task AddAsync(Order entity, CancellationToken ct = default);
    Task UpdateAsync(Order entity, CancellationToken ct = default);
    Task DeleteAsync(Order entity, CancellationToken ct = default);
}