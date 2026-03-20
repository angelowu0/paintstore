using System;
using System.ComponentModel.DataAnnotations;
using PaintStore.Models.DTOs.PaintProducts;

namespace PaintStore.Models.DTOs.Orders;

public class CreateOrderRequest
{
    [Required]
    public int UserId { get; set; }

    // We will use paintproduct ids

    public List<int> Products { get; set; }
}
