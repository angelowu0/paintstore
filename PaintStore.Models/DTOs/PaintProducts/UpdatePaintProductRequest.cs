using System;
using System.ComponentModel.DataAnnotations;

namespace PaintStore.Models.DTOs.PaintProducts;

public class UpdatePaintProductRequest
{
    public string? Name { get; set; }
    [Range(1, int.MaxValue)]

    public decimal? Price { get; set; }
    [Range(1, int.MaxValue)]
    public int? Quantity { get; set; }
}
