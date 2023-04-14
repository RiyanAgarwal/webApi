using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{

    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddMovie([FromBody] int Id)
        {
            return Created($"~api/genres/{Id}", Id);
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            return Ok();
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetGenreById(int Id)
        {
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteGenre(int Id)
        {
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateGenre(int Id)
        {
            return Ok();
        }

    }
}
