using System;
using AutoMapper;
using PaintStore.Models.DTOs;
using PaintStore.Models.DTOs.Orders;
using PaintStore.Models.DTOs.PaintProducts;
using PaintStore.Models.Models;

namespace PaintStore.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // 2 types, type 1 is source, type 2 is destination
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UserResponse>();

        CreateMap<CreateOrderRequest, Order>();
        CreateMap<UpdateOrderRequest, Order>();
        CreateMap<Order, OrderResponse>();

        CreateMap<CreatePaintProductRequest, PaintProduct>();
        CreateMap<UpdatePaintProductRequest, PaintProduct>();
        CreateMap<PaintProduct, PaintProductResponse>();
    }
}
