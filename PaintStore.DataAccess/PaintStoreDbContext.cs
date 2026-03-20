using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.Models.Models;

namespace PaintStore.DataAccess;

public class PaintStoreDbContext : DbContext
{
    public PaintStoreDbContext(DbContextOptions<PaintStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<PaintProduct> Products { get; set; }
}
