using System;
using SampleProject.Enums;

namespace SampleProject.Models;

public class Payment(Order order, int paymentId, PaymentStatus status, decimal amount, PaymentMethod method, User user)
{
    public Order Order { get; } = order;
    public int Id { get; } = paymentId;
    public PaymentStatus Status { get; } = status;
    public decimal Amount { get; } = amount;
    public PaymentMethod method { get; } = method;
    public User User { get; } = user;

}