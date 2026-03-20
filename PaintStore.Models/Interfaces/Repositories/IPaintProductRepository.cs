using System;
using PaintStore.Models.Models;

namespace PaintStore.Models.Interfaces.Repositories;

public interface IPaintProductRepository
{
    public PaintProduct CreatePaintProduct(PaintProduct paintProduct);

    public List<PaintProduct> GetPaintProducts();

    public PaintProduct? GetPaintProductById(int id);

    public PaintProduct? UpdatePaintProduct(int id, PaintProduct paintProduct);

    public PaintProduct? DeletePaintProduct(int id);

    // public List<PaintProduct> GetPaintProductsByFilter();

    public List<PaintProduct> GetPaintProductsByIds(List<int> ids);
}
