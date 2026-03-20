using System;

namespace PaintStore.Models.DTOs.PaintProducts;

public class PaintProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
