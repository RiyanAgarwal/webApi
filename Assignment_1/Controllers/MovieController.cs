using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment_1.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddMovie([FromBody] int Id)
        {
            return Created($"~api/movies/{Id}",Id);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok();
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetMovieById(int Id)
        {
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteMovie(int Id)
        {
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateMovie(int Id)
        {
            return Ok();
        }

    }
}
