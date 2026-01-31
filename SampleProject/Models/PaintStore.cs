using System;

namespace SampleProject.Models;

public class PaintStore(PaintProduct[] products)
{
    public PaintProduct[] Products { get; } = products;

    public override string ToString()
    {
        string products = "";
        foreach (var product in Products)
        {
            products += $"{product}\n";
        }
        return products;
    }
}
