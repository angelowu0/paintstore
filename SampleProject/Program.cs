using SampleProject.Enums;
using SampleProject.Models;

public class Program()
{
    static void Main(string[] args)
    {
        Brand brand1 = new Brand("Dulux");
        var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
        var paint2 = new PaintProduct(brand1, "paint2", PaintType.Glossy, new PaintSpecification("green", 5), 15m, 0.2m);
        var paint3 = new PaintProduct(brand1, "paint3", PaintType.Matte, new PaintSpecification("blue", 5), 10m, 0.05m);
        var paint4 = new PaintProduct(brand1, "paint4", PaintType.Gloss, new PaintSpecification("blue", 5), 10m, 0.05m);
        var paint5 = new PaintProduct(brand1, "paint5", PaintType.SemiGloss, new PaintSpecification("blue", 5), 10m, 0.05m);
        var paint6 = new PaintProduct(brand1, "paint6", PaintType.WhiteOnWhite, new PaintSpecification("blue", 5), 10m, 0.05m);
        paint1.DisplayInfo();
        paint2.DisplayInfo();
        paint3.DisplayInfo();
        paint4.DisplayInfo();
        paint5.DisplayInfo();
        paint6.DisplayInfo();
        var order1 = new SingleItemOrder(paint1, 20);
        var order2 = new SingleItemOrder(paint2, 10);
        var order3 = new SingleItemOrder(paint3, 5);
        order1.DisplayOrder();
        order2.DisplayOrder();
        order3.DisplayOrder();
        var orderCombined = new Order([order1, order2, order3]);
        orderCombined.GetTotalPrice();
        Console.WriteLine("combinedorder\n"+orderCombined+orderCombined.GetTotalPrice());
        var store1 = new PaintStore([paint1, paint2]);
        Console.WriteLine("store1\n"+store1);
    }
}