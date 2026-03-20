using System;
using AutoMapper;
using Microsoft.VisualBasic;
using PaintStore.Models.DTOs.PaintProducts;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Models.Interfaces.Services;
using PaintStore.Models.Models;

namespace PaintStore.Services.Services;

public class PaintProductService(IPaintProductRepository repo, IMapper mapper) : IPaintProductService
{
    private IMapper _mapper = mapper;

    private readonly IPaintProductRepository _repo = repo;
    public PaintProductResponse CreatePaintProduct(CreatePaintProductRequest createPaintProductRequest)
    {
        var paintProduct = _mapper.Map<PaintProduct>(createPaintProductRequest);

        var newPaintProduct = _repo.CreatePaintProduct(paintProduct);

        var paintProductResponse = _mapper.Map<PaintProductResponse>(newPaintProduct);
        return paintProductResponse;
    }

    public PaintProductResponse DeletePaintProduct(int id)
    {
        var deletedPaintProduct = _repo.DeletePaintProduct(id);

        var deletedPaintProductResponse = _mapper.Map<PaintProductResponse>(deletedPaintProduct);

        return deletedPaintProductResponse;
    }

    public PaintProductResponse GetPaintProductById(int id)
    {
        var paintProduct = _repo.GetPaintProductById(id);

        var paintProductResponse = _mapper.Map<PaintProductResponse>(paintProduct);
        return paintProductResponse;
    }

    public List<PaintProductResponse> GetPaintProducts()
    {
        var paintProducts = _repo.GetPaintProducts();

        var paintProductsResponse = _mapper.Map<List<PaintProductResponse>>(paintProducts);

        return paintProductsResponse;
    }

    public List<PaintProductResponse> GetPaintProductsByFilter()
    {
        throw new NotImplementedException();
    }

    public PaintProductResponse? UpdatePaintProduct(int id, UpdatePaintProductRequest updatePaintProductRequest)
    {
        var paintProduct = _mapper.Map<PaintProduct>(updatePaintProductRequest);

        if (_repo.GetPaintProductById(id) == null) return null;

        var updatedPaintProduct = _repo.UpdatePaintProduct(id, paintProduct);

        var paintProductResponse = _mapper.Map<PaintProductResponse>(updatedPaintProduct);

        return paintProductResponse;
    }
}
