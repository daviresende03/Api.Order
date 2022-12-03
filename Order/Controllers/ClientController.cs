using Microsoft.AspNetCore.Mvc;
using Order.Application.DataContract.Request.Client;
using Order.Application.Interfaces;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplication _clientApplication;
        public ClientController(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateClientRequest request)
        {
            var response = await _clientApplication.CreateAsync(request);
            
            if (response.Report.Any())
                return UnprocessableEntity(response.Report);
            
            return Ok(response);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
