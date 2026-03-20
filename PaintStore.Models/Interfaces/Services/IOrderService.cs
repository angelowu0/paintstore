using System;
using PaintStore.Models.DTOs.Orders;
using PaintStore.Models.Models;

namespace PaintStore.Models.Interfaces.Services;
public interface IOrderService
{
    public OrderResponse CreateOrder(CreateOrderRequest request);

    public List<OrderResponse> GetOrders();

    public OrderResponse? GetOrderById(int id);

    public OrderResponse? UpdateOrder(int id, UpdateOrderRequest request);

    public OrderResponse? DeleteOrder(int id);

    public List<OrderResponse> GetOrdersByUserId(int userId);
}
