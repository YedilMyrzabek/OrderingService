using AutoMapper;
using Ordering.Application.DTOs;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mapping;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderDto.OrderCreateDto, Order>();
        CreateMap<Order, OrderDto.OrderReadDto>();
    }
}