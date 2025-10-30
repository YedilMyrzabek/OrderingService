using BuildingBlocks.Application.Interfaces;
using Ordering.Application.Models;

namespace Ordering.Application.Interfaces;

public interface IOrderService: IGenericService<OrderCreateDto, OrderReadDto, OrderUpdateDto>
{
}