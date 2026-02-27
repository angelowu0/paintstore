using System;

namespace PaintStore.API.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        Orders = new List<Order>();
    }

}
