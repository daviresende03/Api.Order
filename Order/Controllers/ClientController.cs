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
        public async Task<IActionResult> Get([FromQuery] string name = "")
        {
            var response = await _clientApplication.ListByFilterAsync(name: name);

            if (response.Report.Any())
                return UnprocessableEntity(response.Report);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _clientApplication.GetByIdAsync(id);

            if (response.Report.Any())
                return UnprocessableEntity(response.Report);

            return Ok(response);
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
