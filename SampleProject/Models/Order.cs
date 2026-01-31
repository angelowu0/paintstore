using System;

namespace SampleProject.Models;

public class Order(SingleItemOrder[] ordersArray)
{
    public SingleItemOrder[] OrdersArray { get; } = ordersArray;

    public decimal GetTotalPrice()
    {
        decimal price = 0;
        foreach (SingleItemOrder order in OrdersArray)
        {
            price += order.GetTotalPrice();
        }
        return price;
    }

    public override string ToString()
    {
        string orders = "";
        foreach (SingleItemOrder order in OrdersArray)
        {
            orders += $"{order}\n";
        }

        return orders;
    }
}
