using Microsoft.AspNetCore.Mvc;
using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderSystem.Infrastructure.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService service) 
        { 
            _orderService = service;
        }
        
        // GET: api/<OrdersController>
        [HttpGet]
        public BaseResonse<IEnumerable<string>> Get()
        {
            _orderService.GetAllOrders();
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public BaseResonse<string> Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public BaseResonse<Order> Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public BaseResonse<Order> Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public BaseResonse<bool> Delete(int id)
        {
        }
    }
}
