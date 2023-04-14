using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{

    [Route("api/producers")]
    [ApiController]
    public class ProducerController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddProducer([FromBody] int Id)
        {
            return Created($"~api/producers/{Id}", Id);
        }

        [HttpGet]
        public IActionResult GetProducers()
        {
            return Ok();
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetProducerById(int Id)
        {
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteProducer(int Id)
        {
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateProducer(int Id)
        {
            return Ok();
        }

    }
}
