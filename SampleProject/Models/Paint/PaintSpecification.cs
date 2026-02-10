using System;

namespace SampleProject.Models;

public class PaintSpecification(string colour, int sizeInLitres)
{
    public string Colour { get; set; } = colour;
    public int SizeInLitres { get; set; } = sizeInLitres;

    public override string ToString()
    {
        return $"Colour: {Colour} Size(L): {SizeInLitres}";
    }
    public void DisplaySpecification()
    {
        Console.WriteLine(ToString());
    }
}