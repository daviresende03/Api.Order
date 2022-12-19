using Microsoft.AspNetCore.Mvc;
using Order.Application.Interfaces;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderApplication _orderApplication;

        public OrderController(IOrderApplication orderApplication)
        {
            _orderApplication = orderApplication;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get(int? orderId = 0,int? clientId = 0, int? userId = 0)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
