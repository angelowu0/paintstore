using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models.Interfaces.Services;
using AutoMapper;
using PaintStore.Models.Models;
using PaintStore.Models.DTOs.Orders;


namespace PaintStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        private ILogger<OrderController> _logger;


        public OrderController(IOrderService service, ILogger<OrderController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateOrder([FromBody] CreateOrderRequest createOrderRequest)
        {
            _logger.LogInformation("Create Order: Received request");

            var newOrderResponse = _service.CreateOrder(createOrderRequest);

            _logger.LogInformation("Created Order: Order created with id");
            return Created($"/api/Orders/{newOrderResponse.Id}", newOrderResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOrders()
        {
            List<OrderResponse> Orders = _service.GetOrders();

            return Ok(Orders);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrderById(int id)
        {
            var Order = _service.GetOrderById(id);

            if (Order == null) return NotFound();

            return Ok(Order);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateOrder(int id, [FromBody] UpdateOrderRequest updateOrderRequest)
        {


            var updatedOrderResponse = _service.UpdateOrder(id, updateOrderRequest);

            if (updatedOrderResponse == null) return NotFound();


            return Ok(updatedOrderResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteOrder(int id)
        {

            var deletedOrderResponse = _service.DeleteOrder(id);


            return Ok(deletedOrderResponse);
        }

        // [HttpPost("CreateOrder")]
        // public IActionResult CreateOrder([FromBody] Order order)
        // {
        //     _dbContext.Orders.Add(order);

        //     _dbContext.SaveChanges();

        //     return Created($"GetOrderById/{order.Id}", order);
        // }

        // [HttpGet("GetOrder/{id}")]
        // public IActionResult GetSelectOrders(int id)
        // {
        //     List<Order> orders = _dbContext.Orders.ToList();

        //     if (orders.Any(order => order.Id == id))
        //     {
        //         return Ok(orders.Select(order => order.Id == id));
        //     }

        //     return NotFound();
        // }

        // [HttpGet("GetOrdersRange")]
        // public IActionResult GetOrdersByPriceRange(decimal min, decimal max)
        // {
        //     List<Order> orders = _dbContext.Orders.ToList();

        //     if (orders.Any(order => order.TotalPrice >= min && order.TotalPrice <= max))
        //     {
        //         return Ok(orders.Select(order => order.TotalPrice >= min && order.TotalPrice <= max));
        //     }

        //     return NotFound();
        // }

        // [HttpGet("GetOrdersByPaintId/{id}")]
        // public IActionResult GetOrdersByPaintId(int id)
        // {
        //     List<Order> orders = _dbContext.Orders.ToList();

        //     if (orders.Any(order => order.Products.Any(product => product.Id == id)))
        //     {
        //         return Ok(orders.Select(order => order.Products.Any(product => product.Id == id)));
        //     }

        //     return NotFound();
        // }

        // [HttpGet("GetOrdersByUserId/{id}")]
        // public IActionResult GetOrdersByUserId(int id)
        // {
        //     List<Order> orders = _dbContext.Orders.ToList();

        //     if (orders.Any(order => order.UserId == id))
        //     {
        //         return Ok(orders.Select(order => order.UserId == id));
        //     }

        //     return NotFound();
        // }

        // [HttpGet("GetLastMonthOrders")]
        // public IActionResult GetLastMonthOrders()
        // {
        //     List<Order> orders = _dbContext.Orders.ToList();

        //     if (orders.Any(order => order.CreatedDate >= DateTime.Now.AddMonths(-1)))
        //     {
        //         return Ok(orders.Select(order => order.CreatedDate >= DateTime.Now.AddMonths(-1)));
        //     }

        //     return NotFound();
        // }

        // [HttpGet("GetOrdersByDate")]
        // public IActionResult GetOrdersByDate(DateTime date)
        // {
        //     List<Order> orders = _dbContext.Orders.ToList();

        //     if (orders.Any(order=>order.CreatedDate == date))
        //     {
        //         return Ok(orders.Select(order=>order.CreatedDate == date));
        //     }

        //     return NotFound();
        // }
    }
}
