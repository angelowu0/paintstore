using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.Models;
using PaintStore.API.DataAccess;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintProductController : ControllerBase
    {
        private PaintStoreDbContext _dbContext;
        public PaintProductController(PaintStoreDbContext paintStoreDb)
        {
            _dbContext = paintStoreDb;
        }

        [HttpPost()]
        public IActionResult CreatePaintProduct([FromBody] PaintProduct product)
        {
            _dbContext.Products.Add(product);

            _dbContext.SaveChanges();

            return Created($"GetProductById/{product.Id}", product);
        }

        [HttpGet("GetPaintProducts")]
        public IActionResult GetAllPaintProducts()
        {
            List<PaintProduct> paintProducts = _dbContext.Products.ToList();

            if (paintProducts.Any())
            {
                return Ok(paintProducts);
            }

            return NotFound();
        }


        [HttpGet("GetProductsByPriceRange")]
        public IActionResult GetProductsByPriceRange(decimal min, decimal max)
        {
            List<PaintProduct> paintProducts = _dbContext.Products.ToList();
            if (paintProducts.Any(paint => paint.Price >= min && paint.Price <= max))
            {
                return Ok(paintProducts.Select(paint => paint.Price >= min && paint.Price <= max));
            }

            return NotFound();
        }
    }
}
