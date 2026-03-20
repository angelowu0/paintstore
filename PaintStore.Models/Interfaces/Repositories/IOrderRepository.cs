using System;
using PaintStore.Models.Models;

namespace PaintStore.Models.Interfaces.Repositories;

public interface IOrderRepository
{
    public Order CreateOrder(Order Order);

    public List<Order> GetOrders();

    public Order? GetOrderById(int id);

    public Order? UpdateOrder(int id, Order Order);

    public Order? DeleteOrder(int id);

    public List<Order> GetOrdersByUserId(int userId);
}
