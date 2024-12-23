using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderMicroService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static readonly List<Order> Orders = new List<Order>
        {
            new Order { OrderId = 1, ProductName = "Product A", Quantity = 1, Price = 10 },
            new Order { OrderId = 2, ProductName = "Product B", Quantity = 2, Price = 20 }
        };

        // GET: api/order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(Orders);
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.OrderId = Orders.Max(o => o.OrderId) + 1; // Assign new OrderId
            Orders.Add(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;
    }
}