using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{

    [Route("api/movies/{movieId:int}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddReview(int movieId,[FromBody] int Id)
        {
            return Created($"~api/movies/{movieId}/{Id}", Id);
        }

        [HttpGet]
        public IActionResult GetReviews(int movieId)
        {
            return Ok();
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetReviewById(int movieId, int Id)
        {
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteReview(int movieId, int Id)
        {
            return NoContent();
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateReview(int movieId, int Id)
        {
            return NoContent();
        }

    }
}
