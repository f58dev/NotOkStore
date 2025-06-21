using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "T-shirt", Price = 19.99M, Description = "Simple cotton t-shirt" },
            new Product { Id = 2, Name = "Jeans", Price = 49.99M, Description = "Blue jeans" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return Ok(product);
        }
    }
}