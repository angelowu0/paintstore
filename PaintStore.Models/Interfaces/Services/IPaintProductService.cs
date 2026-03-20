using System;
using PaintStore.Models.DTOs.PaintProducts;
using PaintStore.Models.Models;

namespace PaintStore.Models.Interfaces.Services;

public interface IPaintProductService
{
    public PaintProductResponse CreatePaintProduct(CreatePaintProductRequest request);

    public List<PaintProductResponse> GetPaintProducts();

    public PaintProductResponse? GetPaintProductById(int id);

    public PaintProductResponse? UpdatePaintProduct(int id, UpdatePaintProductRequest request);

    public PaintProductResponse? DeletePaintProduct(int id);

    public List<PaintProductResponse> GetPaintProductsByFilter();
}
