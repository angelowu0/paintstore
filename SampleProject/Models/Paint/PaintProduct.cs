using System;
using System.ComponentModel.DataAnnotations;
using SampleProject.Enums;
using SampleProject.Interfaces;

namespace SampleProject.Models;

public class PaintProduct : IBuyable
{
    public decimal TaxRate
    {
        get;
    }

    public PaintProduct() {}

    public PaintProduct(Brand brand, string name, PaintType type, PaintSpecification specification, decimal price, decimal taxRatePaint = 0.10m)
    {
        Brand = brand;
        Name = name;
        Type = type;
        Specification = specification;
        Price = price;
        TaxRate = taxRatePaint;
    }

    const decimal defaultDiscount = 0.05m;
    public Brand Brand { get; }

    [MaxLength(50)]
    public string Name { get; }
    public PaintType Type { get; }
    public PaintSpecification Specification { get; }

    [Required]
    public decimal Price { get; }

    public decimal GetFinalPrice()
    {
        var price = Price;
        price *= 1 + TaxRate;
        price *= 1 - defaultDiscount;
        return price;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(this);
    }

    public virtual decimal GetMaxDiscount(int rate)
    {
        return (defaultDiscount > rate)?defaultDiscount:rate;
    }

    public override string ToString()
    {
        return $"Brand: {Brand.Name} Name: {Name} Type: {Type} {Specification} Price: {GetFinalPrice()}";
    }
}
