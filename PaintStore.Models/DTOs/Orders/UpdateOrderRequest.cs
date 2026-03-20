using System;
using System.ComponentModel.DataAnnotations;
using PaintStore.Models.DTOs.PaintProducts;

namespace PaintStore.Models.DTOs.Orders;

public class UpdateOrderRequest
{
    public int? UserId { get; set; }

    public List<int>? Products { get; set; }
}
