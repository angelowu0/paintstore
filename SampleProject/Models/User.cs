using System;
using SampleProject.Enums;

namespace SampleProject.Models;

public class User(string name, int age)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;

    public void DisplayUserInfo()
    {
        string description = $"{Name} {Age}";
        Console.WriteLine(description);
    }

    public List<Order> OrderHistory { get; set; } = [];

    public Order GetHighestOrder()
    {
        if (OrderHistory == null || OrderHistory.Count == 0)
        {
            throw new Exception();
        }

        Order order = OrderHistory.MaxBy(order => order.GetTotalPrice()) ?? throw new Exception();
        return order;
    }

    public Order GetLatestOrder()
    {
        Order latestOrder = OrderHistory.LastOrDefault() ?? throw new Exception();
        return latestOrder;
    }

    public List<Payment> PaymentHistory { get; set; } = [];

    public Payment GetLowestPayment()
    {
        if (PaymentHistory == null || PaymentHistory.Count() == 0)
        {
            throw new Exception();
        }

        Payment payment = PaymentHistory.MinBy(payment => payment.Amount) ?? throw new Exception();
        return payment;
    }

    public Payment GetLatestPayment()
    {
        Payment latestPayment = PaymentHistory.LastOrDefault() ?? throw new Exception();
        return latestPayment;
    }

    public Payment[] GetPaymentsGreaterThan10()
    {
        return [.. PaymentHistory.Where(payment => payment.Amount > 10)];
    }
}
