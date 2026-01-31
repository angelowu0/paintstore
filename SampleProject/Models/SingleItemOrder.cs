using System;

namespace SampleProject.Models;

public class SingleItemOrder(PaintProduct product, int quantity)
{
    public readonly DateTime createdAt = DateTime.Now;
    public DateTime CreatedAt
    {
        get { return createdAt; }
    }

    public PaintProduct Product { get; } = product;
    public int Quantity { get; } = quantity;
    public decimal TotalPrice = product.GetFinalPrice() * quantity;

    public void DisplayOrder()
    {
        Console.WriteLine(this);
    }

    public decimal GetTotalPrice()
    {
        return TotalPrice;
    }

    public override string ToString()
    {
        return $"Product: {Product.Name} Quantity: {Quantity} TotalPrice: {TotalPrice}";
    }
}
