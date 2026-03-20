using System;
using PaintStore.DataAccess;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Models;

namespace PaintStore.Repositories;

public class PaintProductRepository(PaintStoreDbContext db) : IPaintProductRepository
{
    private readonly PaintStoreDbContext _db = db;

    public PaintProduct CreatePaintProduct(PaintProduct paintProduct)
    {
        _db.Products.Add(paintProduct);
        _db.SaveChanges();
        return paintProduct;
    }

    public PaintProduct? DeletePaintProduct(int id)
    {
        PaintProduct? paintProduct = GetPaintProductById(id);
        if (paintProduct == null) return null;
        _db.Products.Remove(paintProduct);
        return paintProduct;
    }

    public PaintProduct? GetPaintProductById(int id)
    {
        PaintProduct? paintProduct = _db.Products.FirstOrDefault(paintProduct => paintProduct.Id == id);
        return paintProduct;
    }

    public List<PaintProduct> GetPaintProducts()
    {
        List<PaintProduct> paintProducts = [.. _db.Products];
        return paintProducts;
    }

    public PaintProduct? UpdatePaintProduct(int id, PaintProduct updatedPaintProduct)
    {
        PaintProduct? paintProduct = GetPaintProductById(id);
        if (paintProduct == null) return null;
        paintProduct.Name = updatedPaintProduct.Name;
        paintProduct.Price = updatedPaintProduct.Price;
        paintProduct.Inventory = updatedPaintProduct.Inventory;
        _db.SaveChanges();
        return paintProduct;
    }

    public List<PaintProduct> GetPaintProductsByIds(List<int> ids)
    {
        List<PaintProduct> paintProducts = [.. _db.Products.Where(product => ids.Contains(product.Id))];
        return paintProducts;
    }

}
