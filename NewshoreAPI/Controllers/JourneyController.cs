using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewshoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly ILogger<JourneyController> _logger;
        private readonly IDisponibilityBusiness _disponibilityBusiness;

        public JourneyController(ILogger<JourneyController> logger, IDisponibilityBusiness disponibilityBusiness)
        {
            _logger = logger;
            _disponibilityBusiness = disponibilityBusiness;
        }

        // GET: api/<JourneyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JourneyController>/5
        [HttpGet("{origin}/{destination}")]
        public ActionResult Get(string origin, string destination)
        {
            var journey = _disponibilityBusiness.GetDisponibility(new Domain.Models.Request() { Origin = origin, Destination = destination });
            return Ok(journey);
        }

        // POST api/<JourneyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JourneyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JourneyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
