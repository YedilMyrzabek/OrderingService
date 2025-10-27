using AutoMapper;
using Ordering.Application.Abstractions.Persistence;
using Ordering.Application.DTOs;
using Ordering.Application.Interfaces;
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

    public async Task<OrderDto.OrderReadDto> CreateAsync(
        OrderDto.OrderCreateDto dto, 
        CancellationToken ct = default)
    {
        var exists = await _repo.GetByNumberAsync(dto.Number, ct);
        if (exists is not null) throw new InvalidOperationException($"Order '{dto.Number}' already exists");

        var entity = _mapper.Map<Order>(dto);
        await _repo.AddAsync(entity, ct);
        return _mapper.Map<OrderDto.OrderReadDto>(entity);
    }

    public async Task<OrderDto.OrderReadDto?> GetByIdAsync(
        Guid id, 
        CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        return entity is null ? null : _mapper.Map<OrderDto.OrderReadDto>(entity);
    }

    public async Task<List<OrderDto.OrderReadDto>> GetPagedAsync(int pageIndex, int pageSize, CancellationToken ct)
    {
        var orders = await _repo.GetPagedAsync(pageIndex, pageSize, ct);
        return _mapper.Map<List<OrderDto.OrderReadDto>>(orders);
    }

    public async Task<OrderDto.OrderReadDto?> UpdateAsync(
        Guid id, 
        OrderDto.OrderUpdateDto dto, 
        CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        if (entity is null) return null;

        entity.CustomerName = dto.CustomerName;
        entity.TotalAmount  = dto.TotalAmount;
        entity.Status       = dto.Status;
        entity.UpdatedAtUtc = DateTime.UtcNow;

        await _repo.UpdateAsync(entity, ct);
        return _mapper.Map<OrderDto.OrderReadDto>(entity);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        if (entity is null) return false;
        await _repo.DeleteAsync(entity, ct);
        return true;
    }
}