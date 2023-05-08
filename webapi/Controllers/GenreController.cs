using Assignment_3.Models.Request;
using Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment_3.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        readonly IGenreService _genreService;
        public GenreController(IGenreService genreService) => _genreService = genreService;

        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreRequest genre)
        {
            try
            {
                var createdGenreId = _genreService.Create(genre);
                return Created($"~api/genres/{createdGenreId}", createdGenreId);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            try
            {
                return Ok(_genreService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetGenreById(int Id)
        {
            try
            {
                return Ok(_genreService.Get(Id));
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteGenre(int Id)
        {
            try
            {
                _genreService.Delete(Id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateGenre(int Id, GenreRequest genre)
        {
            try
            {
                _genreService.Update(Id, genre);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}