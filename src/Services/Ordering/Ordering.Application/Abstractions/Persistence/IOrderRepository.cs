using BuildingBlocks.Infrastructure.Repositories;
using Ordering.Domain.Entities;

namespace Ordering.Application.Abstractions.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
}