using Assignment_4.Models.Request;
using Assignment_4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Firebase.Storage;
using System.Threading.Tasks;

namespace Assignment_4.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        readonly IMovieService _movieService;
        public MovieController(IMovieService movieService) => _movieService = movieService;

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file,[FromForm]int id)
        {
        
            if (file == null || file.Length == 0)
                return Content("file not selected");
            try
            {
                var task = await new FirebaseStorage("smart-acrobat-384720.appspot.com")
                .Child("webapi")
                .Child(Guid.NewGuid().ToString() + ".jpg")
                .PutAsync(file.OpenReadStream());
                _movieService.UpdateCoverImage(id, task);
                return Ok(task);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieRequest movie)
        {
            try
            {
                var createdMovieId = _movieService.Create(movie);
                return Created($"~api/movies/{createdMovieId}", createdMovieId);
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
        public IActionResult GetMovies()
        {
            try
            {
                return Ok(_movieService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetMovieById(int Id)
        {
            try
            {
                return Ok(_movieService.Get(Id));
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
        public IActionResult DeleteMovie(int Id)
        {
            try
            {
                _movieService.Delete(Id);
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
        public IActionResult UpdateMovie(int Id, MovieRequest movie)
        {
            try
            {
                _movieService.Update(Id, movie);
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