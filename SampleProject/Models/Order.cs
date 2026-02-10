using System;

namespace SampleProject.Models;

public class Order(SingleItemOrder[] ordersArray)
{
    public SingleItemOrder[] OrdersArray { get; set; } = ordersArray;

    public decimal GetTotalPrice()
    {
        decimal price = 0;
        foreach (SingleItemOrder order in OrdersArray)
        {
            price += order.GetTotalPrice();
        }
        return price;
    }

    public PaintProduct GetMostExpensivePaintProduct()
    {
        if (OrdersArray == null || OrdersArray.Length == 0)
        {
            throw new Exception("Empty list");
        }

        SingleItemOrder order = OrdersArray.MaxBy(order => order.Product.GetFinalPrice()) ?? throw new Exception();

        return order.Product;
    }

    public decimal TotalPriceOfSinglePaint(string paintId)
    {
        SingleItemOrder? order = OrdersArray.FirstOrDefault(order => order.Product.Name == paintId) ?? throw new Exception();
        return order.TotalPrice;
    }

    public void RemoveProduct(string paintId)
    {
        OrdersArray = [.. OrdersArray.Where(item => item.Product.Name != paintId)];
    }

    public PaintProduct[] PriceBetweenRange(decimal min, decimal max)
    {
        return [.. OrdersArray.Where(order => min <= order.Product.GetFinalPrice() && order.Product.GetFinalPrice() <= max).Select(order => order.Product)];
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
