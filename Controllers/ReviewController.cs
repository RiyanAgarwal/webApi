using Assignment_2.Models.Request;
using Assignment_2.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment_2.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService) => _reviewService = reviewService;

        [HttpPost]
        public IActionResult AddReview([FromBody] ReviewRequest review)
        {
            try
            {
                var createdReviewId = _reviewService.Create(review);
                return Created($"~api/reviews/{createdReviewId}", createdReviewId);
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
        public IActionResult GetReviews()
        {
            try
            {
                return Ok(_reviewService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetReviewById(int Id)
        {
            try
            {
                return Ok(_reviewService.Get(Id));
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
        public IActionResult DeleteReview(int Id)
        {
            try
            {
                _reviewService.Delete(Id);
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
        public IActionResult UpdateReview(int Id, ReviewRequest review)
        {
            try
            {
                _reviewService.Update(Id, review);
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