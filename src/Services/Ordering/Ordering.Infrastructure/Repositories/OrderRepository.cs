using Microsoft.EntityFrameworkCore;
using Ordering.Application.Abstractions.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderingDbContext _context;

    public OrderRepository(OrderingDbContext context)
    {
        _context = context;
    }

    public Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id, ct);

    public Task<Order?> GetByNumberAsync(string number, CancellationToken ct = default) =>
        _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Number == number, ct);

    public async Task<List<Order>> GetPagedAsync(int pageIndex = 1, int pageSize = 10, CancellationToken ct = default)
    {
        return await _context.Orders
            .OrderBy(o => o.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }
    
    public async Task AddAsync(Order entity, CancellationToken ct = default)
    {
        if (entity.Id == default) entity.Id = Guid.NewGuid();
        await _context.Orders.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Order entity, CancellationToken ct = default)
    {
        _context.Orders.Update(entity);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Order entity, CancellationToken ct = default)
    {
        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync(ct);
    }
}