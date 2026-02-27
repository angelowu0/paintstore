using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.DataAccess;
using PaintStore.API.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private PaintStoreDbContext _dbContext;
        public OrderController(PaintStoreDbContext paintStoreDb)
        {
            _dbContext = paintStoreDb;
        }

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();

            return Created($"GetOrderById/{order.Id}", order);
        }

        [HttpGet("GetOrder/{id}")]
        public IActionResult GetSelectOrders(int id)
        {
            List<Order> orders = _dbContext.Orders.ToList();

            if (orders.Any(order => order.Id == id))
            {
                return Ok(orders.Select(order => order.Id == id));
            }

            return NotFound();
        }

        [HttpGet("GetOrdersRange")]
        public IActionResult GetOrdersByPriceRange(decimal min, decimal max)
        {
            List<Order> orders = _dbContext.Orders.ToList();

            if (orders.Any(order => order.TotalPrice >= min && order.TotalPrice <= max))
            {
                return Ok(orders.Select(order => order.TotalPrice >= min && order.TotalPrice <= max));
            }

            return NotFound();
        }

        [HttpGet("GetOrdersByPaintId/{id}")]
        public IActionResult GetOrdersByPaintId(int id)
        {
            List<Order> orders = _dbContext.Orders.ToList();

            if (orders.Any(order => order.Products.Any(product => product.Id == id)))
            {
                return Ok(orders.Select(order => order.Products.Any(product => product.Id == id)));
            }

            return NotFound();
        }

        [HttpGet("GetOrdersByUserId/{id}")]
        public IActionResult GetOrdersByUserId(int id)
        {
            List<Order> orders = _dbContext.Orders.ToList();

            if (orders.Any(order => order.UserId == id))
            {
                return Ok(orders.Select(order => order.UserId == id));
            }

            return NotFound();
        }

        [HttpGet("GetLastMonthOrders")]
        public IActionResult GetLastMonthOrders()
        {
            List<Order> orders = _dbContext.Orders.ToList();

            if (orders.Any(order => order.CreatedDate >= DateTime.Now.AddMonths(-1)))
            {
                return Ok(orders.Select(order => order.CreatedDate >= DateTime.Now.AddMonths(-1)));
            }

            return NotFound();
        }

        [HttpGet("GetOrdersByDate")]
        public IActionResult GetOrdersByDate(DateTime date)
        {
            List<Order> orders = _dbContext.Orders.ToList();

            if (orders.Any(order=>order.CreatedDate == date))
            {
                return Ok(orders.Select(order=>order.CreatedDate == date));
            }

            return NotFound();
        }
    }
}
