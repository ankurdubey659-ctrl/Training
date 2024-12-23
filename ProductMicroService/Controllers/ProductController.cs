using Microsoft.AspNetCore.Mvc;

namespace ProductMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 1000 },
        new Product { Id = 2, Name = "Phone", Price = 500 }
    };

        [HttpGet]
        public ActionResult<List<Product>> GetProducts() => Ok(products);
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
