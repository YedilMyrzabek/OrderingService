using AutoMapper;
using Ordering.Application.Abstractions.Persistence;
using Ordering.Application.Interfaces;
using Ordering.Application.Models;
using Ordering.Domain.Entities;


namespace Ordering.Application.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<OrderReadDto> CreateAsync(OrderCreateDto dto, CancellationToken ct = default)
    {
        var exists = await _repo.GetByNumberAsync(dto.Number, ct);
        if (exists is not null) throw new InvalidOperationException($"Order '{dto.Number}' already exists");

        var entity = _mapper.Map<Order>(dto);
        await _repo.AddAsync(entity, ct);
        return _mapper.Map<OrderReadDto>(entity);
    }

    public async Task<OrderReadDto?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var entity =  await _repo.GetByIdAsync(id, ct);
        return entity is null ? null : _mapper.Map<OrderReadDto>(entity);
    }

    public async Task<List<OrderReadDto>> GetPagedAsync(int pageIndex, int pageSize, CancellationToken ct)
    {
        var orders = await _repo.GetPagedAsync(pageIndex, pageSize, ct);
        return _mapper.Map<List<OrderReadDto>>(orders);
    }

    public async Task<OrderReadDto?> UpdateAsync(Guid id, OrderUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        if (entity is null) return null;

        entity.CustomerName = dto.CustomerName;
        entity.TotalAmount  = dto.TotalAmount;
        entity.Status       = dto.Status;
        entity.UpdatedAtUtc = DateTime.UtcNow;

        await _repo.UpdateAsync(entity, ct);
        return _mapper.Map<OrderReadDto>(entity);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        if (entity is null) return false;
        await _repo.DeleteAsync(entity, ct);
        return true;
    }
}