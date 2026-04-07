using System;

namespace PaintStore.Models.Models;
public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; }

    public List<PaintProduct> Products { get; set; }

    public decimal TotalPrice { get => Products.Sum(product => product.Price); }
    public Order(int id, int userId)
    {
        Id = id;
        UserId = userId;
        CreatedDate = DateTime.Now;
        Products = new List<PaintProduct>();
    }
}
