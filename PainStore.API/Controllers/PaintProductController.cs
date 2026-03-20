using Microsoft.AspNetCore.Mvc;
using PaintStore.Models.DTOs.PaintProducts;
using PaintStore.Models.Interfaces.Services;

namespace PaintStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class PaintProductController : ControllerBase
    {

        private readonly IPaintProductService _service;

        private ILogger<PaintProductController> _logger;


        public PaintProductController(IPaintProductService service, ILogger<PaintProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreatePaintProduct([FromBody] CreatePaintProductRequest createPaintProductRequest)
        {
            _logger.LogInformation("Create PaintProduct: Received request");

            var paintProductResponse = _service.CreatePaintProduct(createPaintProductRequest);

            _logger.LogInformation("Created PaintProduct: PaintProduct created with id");
            return Created($"/api/PaintProducts/{paintProductResponse.Id}", paintProductResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPaintProducts()
        {
            List<PaintProductResponse> paintProductsResponse = _service.GetPaintProducts();

            return Ok(paintProductsResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPaintProductById(int id)
        {
            var PaintProduct = _service.GetPaintProductById(id);

            if (PaintProduct == null) return NotFound();

            return Ok(PaintProduct);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdatePaintProduct(int id, [FromBody] UpdatePaintProductRequest updatePaintProductRequest)
        {

            var updatedPaintProductResponse = _service.UpdatePaintProduct(id, updatePaintProductRequest);

            if (updatedPaintProductResponse == null) return NotFound();

            return Ok(updatedPaintProductResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePaintProduct(int id)
        {

            var deletedPaintProductResponse = _service.DeletePaintProduct(id);

            return Ok(deletedPaintProductResponse);
        }

        // [HttpPost()]
        // public IActionResult CreatePaintProduct([FromBody] PaintProduct product)
        // {
        //     _dbContext.Products.Add(product);

        //     _dbContext.SaveChanges();

        //     return Created($"GetProductById/{product.Id}", product);
        // }

        // [HttpGet("GetPaintProducts")]
        // public IActionResult GetAllPaintProducts()
        // {
        //     List<PaintProduct> paintProducts = _dbContext.Products.ToList();

        //     if (paintProducts.Any())
        //     {
        //         return Ok(paintProducts);
        //     }

        //     return NotFound();
        // }


        // [HttpGet("GetProductsByPriceRange")]
        // public IActionResult GetProductsByPriceRange(decimal min, decimal max)
        // {
        //     List<PaintProduct> paintProducts = _dbContext.Products.ToList();
        //     if (paintProducts.Any(paint => paint.Price >= min && paint.Price <= max))
        //     {
        //         return Ok(paintProducts.Select(paint => paint.Price >= min && paint.Price <= max));
        //     }

        //     return NotFound();
        // }
    }
}
