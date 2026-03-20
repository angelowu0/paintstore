using System;
using System.ComponentModel.DataAnnotations;

namespace PaintStore.Models.DTOs.PaintProducts;

public class CreatePaintProductRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1, int.MaxValue)]

    public decimal Price { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
