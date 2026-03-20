using System;
using System.ComponentModel.DataAnnotations;
using PaintStore.Models.DTOs.PaintProducts;
using PaintStore.Models.Models;

namespace PaintStore.Models.DTOs.Orders;

public class OrderResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public List<int> Products { get; set; }
}
