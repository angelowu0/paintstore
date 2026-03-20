using System;
using PaintStore.DataAccess;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Models;

namespace PaintStore.Repositories;

public class OrderRepository(PaintStoreDbContext db) : IOrderRepository
{

    private readonly PaintStoreDbContext _db = db;
    public Order CreateOrder(Order order)
    {
        _db.Orders.Add(order);
        _db.SaveChanges();
        return order;
    }

    public Order? DeleteOrder(int id)
    {
        Order? order = GetOrderById(id);
        if (order == null) return null;
        _db.Orders.Remove(order);
        return order;
    }

    public Order? GetOrderById(int id)
    {
        Order? order = _db.Orders.FirstOrDefault(order => order.Id == id);
        return order;
    }

    public List<Order> GetOrders()
    {
        List<Order> orders = [.. _db.Orders];
        return orders;
    }

    public List<Order> GetOrdersByUserId(int userId)
    {
        List<Order> orders = [.. _db.Orders.Where(order=>order.UserId == userId)];
        return orders;
    }

    public Order? UpdateOrder(int id, Order updatedOrder)
    {
        Order? order = GetOrderById(id);
        if (order == null) return null;
        order.UserId = updatedOrder.UserId;
        order.Products = updatedOrder.Products;
        _db.SaveChanges();
        return order;
    }
}
