using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;
using SampleProject.Enums;


namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("id")]
        public IActionResult GetAllOrders(int id)
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            var order1 = new SingleItemOrder(paint1, 20);
            List<Order> orders = [new Order(1, 1, [order1])];

            if (orders.Any(order => order.Id == id))
            {
                return Ok(orders.All(order => order.Id == id));
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetOrdersByPriceRange(decimal min, decimal max)
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            var order1 = new SingleItemOrder(paint1, 20);
            List<Order> orders = [new Order(1, 1, [order1])];

            if (orders.Any(order => order.GetTotalPrice() >= min && order.GetTotalPrice() <= max))
            {
                return Ok(orders.All(order => order.GetTotalPrice() >= min && order.GetTotalPrice() <= max));
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetOrdersByPaintId(string id)
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            var order1 = new SingleItemOrder(paint1, 20);
            List<Order> orders = [new Order(1, 1, [order1])];

            if (orders.Any(order => order.OrdersArray.Any(singleorder => singleorder.Product.Name == id)))
            {
                return Ok(orders.All(order => order.OrdersArray.Any(singleorder => singleorder.Product.Name == id)));
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetOrdersByUserId(int id)
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            var order1 = new SingleItemOrder(paint1, 20);
            List<Order> orders = [new Order(1, 1, [order1])];

            if (orders.Any(order => order.UserId == id))
            {
                return Ok(orders.All(order => order.UserId == id));
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetLastMonthOrders(int id)
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            var order1 = new SingleItemOrder(paint1, 20);
            List<Order> orders = [new Order(1, 1, [order1])];

            if (orders.Any(order => order.CreatedDate >= DateTime.Now.AddMonths(-1)))
            {
                return Ok(orders.All(order => order.CreatedDate >= DateTime.Now.AddMonths(-1)));
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetOrdersByDate(DateTime date)
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            var order1 = new SingleItemOrder(paint1, 20);
            List<Order> orders = [new Order(1, 1, [order1])];

            if (orders.Any(order=>order.CreatedDate == date))
            {
                return Ok(orders.All(order=>order.CreatedDate == date));
            }

            return NotFound();
        }
    }
}
