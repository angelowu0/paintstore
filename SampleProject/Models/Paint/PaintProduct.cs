using System;
using SampleProject.Enums;
using SampleProject.Interfaces;

namespace SampleProject.Models;

public class PaintProduct(Brand brand, string name, PaintType type, PaintSpecification specification, decimal price, decimal taxRatePaint = 0.10m) : IBuyable
{
    private readonly decimal taxRate = taxRatePaint;
    public decimal TaxRate
    {
        get { return taxRate; }
    }

    const decimal defaultDiscount = 0.05m;
    public Brand Brand { get; } = brand;

    public string Name { get; } = name;
    public PaintType Type { get; } = type;
    public PaintSpecification Specification { get; } = specification;
    public decimal Price { get; } = price;

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
