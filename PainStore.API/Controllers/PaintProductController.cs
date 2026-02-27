using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;
using SampleProject.Enums;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetAllPaintProducts()
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            List<PaintProduct> paintProducts = [paint1];

            if (paintProducts.Any())
            {
                return Ok(paintProducts);
            }

            return NotFound();
        }


        [HttpGet()]
        public IActionResult GetProductsByPriceRange(decimal min, decimal max)
        {
            Brand brand1 = new Brand("Dulux");
            var paint1 = new PaintProduct(brand1, "paint1", PaintType.BaseCoat, new PaintSpecification("red", 10), 20m);
            List<PaintProduct> paintProducts = [paint1];

            if (paintProducts.Any(paint => paint.GetFinalPrice() >= min && paint.GetFinalPrice() <= max))
            {
                return Ok(paintProducts.Select(paint => paint.GetFinalPrice() >= min && paint.GetFinalPrice() <= max));
            }

            return NotFound();
        }
    }
}
