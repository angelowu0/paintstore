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
        // paint1.DisplayInfo();
        // paint2.DisplayInfo();
        // paint3.DisplayInfo();
        // paint4.DisplayInfo();
        // paint5.DisplayInfo();
        // paint6.DisplayInfo();
        var order1 = new SingleItemOrder(paint1, 20);
        var order2 = new SingleItemOrder(paint2, 10);
        var order3 = new SingleItemOrder(paint3, 5);
        // order1.DisplayOrder();
        // order2.DisplayOrder();
        // order3.DisplayOrder();
        var orderCombined = new Order(1, 1, [order1, order2, order3]);
        // Console.WriteLine(orderCombined.GetTotalPrice());
        Console.WriteLine("Most Expensive\n" + orderCombined.GetMostExpensivePaintProduct());
        // Console.WriteLine("combinedorder\n"+orderCombined+orderCombined.GetTotalPrice());

        Console.WriteLine("price between 0 and 20");
        foreach (var order in orderCombined.PriceBetweenRange(0m, 20m))
        {
            Console.WriteLine(order);
        }

        Console.WriteLine("paint1 total order rprice:" + orderCombined.TotalPriceOfSinglePaint("paint1"));

        orderCombined.RemoveProduct("paint2");
        Console.WriteLine("after removed:\n" + orderCombined);

        // var store1 = new PaintStore([paint1, paint2]);
        // Console.WriteLine("store1\n"+store1);

        var user1 = new User(1, "user1", 20, "a");
        var orderCombined1 = new Order(1, 1,[order1, order2]);
        var orderCombined2 = new Order(1, 2,[order1]);
        var payment1 = new Payment(orderCombined1, 1, PaymentStatus.Pending, 100, PaymentMethod.Alipay, user1);
        var payment2 = new Payment(orderCombined2, 2, PaymentStatus.Pending, 9, PaymentMethod.Alipay, user1);

        user1.OrderHistory.Add(orderCombined1);
        user1.OrderHistory.Add(orderCombined2);
        user1.PaymentHistory.Add(payment2);
        user1.PaymentHistory.Add(payment1);

        Console.WriteLine("hightest order\n" + user1.GetHighestOrder());

        Console.WriteLine("latest order\n" + user1.GetLatestOrder());

        Console.WriteLine("lowest payment\n" + user1.GetLowestPayment());

        Console.WriteLine("latest payment\n" + user1.GetLatestPayment());

        Console.WriteLine("payments greater than 10");
        user1.GetPaymentsGreaterThan10().ToList().ForEach(Console.WriteLine);
    }
}