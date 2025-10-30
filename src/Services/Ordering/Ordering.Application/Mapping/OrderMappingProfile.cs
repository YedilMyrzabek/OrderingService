using AutoMapper;
using Ordering.Application.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mapping;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderCreateDto, Order>();
        CreateMap<Order, OrderReadDto>();
    }
}