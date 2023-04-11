using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{

    [Route("api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddActor([FromBody] int Id)
        {
            return Created($"~api/actors/{Id}",Id);
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            return Ok();
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetActorById(int Id)
        {
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteActor(int Id)
        {
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateActor(int Id)
        {
            return Ok();
        }

    }
}
