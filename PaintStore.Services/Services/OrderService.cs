using System;
using AutoMapper;
using PaintStore.Models.DTOs.Orders;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Interfaces.Services;
using PaintStore.Models.Models;

namespace PaintStore.Services.Services;

public class OrderService(IOrderRepository repo, IMapper mapper, IPaintProductRepository productRepo) : IOrderService {
    private readonly IOrderRepository _repo = repo;

    private readonly IPaintProductRepository _productRepo = productRepo;
    private IMapper _mapper = mapper;



    public OrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
    {
        var Order = _mapper.Map<Order>(createOrderRequest);

        var newOrder = _repo.CreateOrder(Order);

        var createOrderResponse = _mapper.Map<OrderResponse>(newOrder);

        return createOrderResponse;
    }

    public OrderResponse? DeleteOrder(int id)
    {
        var deletedOrder = _repo.DeleteOrder(id);
        var deleteOrderResponse = _mapper.Map<OrderResponse>(deletedOrder);
        return deleteOrderResponse;

    }

    public OrderResponse? GetOrderById(int id)
    {
        var order = _repo.GetOrderById(id);
        var orderRes = _mapper.Map<OrderResponse>(order);
        return orderRes;
    }

    public List<OrderResponse> GetOrders()
    {
        var orders = _repo.GetOrders();
        var ordersRes = _mapper.Map<List<OrderResponse>>(orders);
        return ordersRes;
    }

    public List<OrderResponse> GetOrdersByUserId(int userId)
    {
        var orders = _repo.GetOrdersByUserId(userId);
        var ordersRes = _mapper.Map<List<OrderResponse>>(orders);
        return ordersRes;
    }

    public OrderResponse? UpdateOrder(int id, UpdateOrderRequest updateOrderRequest)
    {
        var order = _mapper.Map<Order>(updateOrderRequest);

        if (_repo.GetOrderById(id) == null) return null;

        if (updateOrderRequest.Products == null) updateOrderRequest.Products = [];

        order.Products = _productRepo.GetPaintProductsByIds(updateOrderRequest.Products);

        var updatedOrder = _repo.UpdateOrder(id, order);

        var updateOrderResponse = _mapper.Map<OrderResponse>(updatedOrder);

        return updateOrderResponse;
    }
}
