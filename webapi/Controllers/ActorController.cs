using Assignment_3.Models.Request;
using Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment_3.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        readonly IActorService _actorService;
        public ActorController(IActorService actorService) => _actorService = actorService;
        [HttpPost]
        public IActionResult AddActor([FromBody] ActorRequest actor)
        {
            try
            {
                var createdActorId = _actorService.Create(actor);
                return Created($"~api/actors/{createdActorId}", createdActorId);
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
        public IActionResult GetActors()
        {
            try
            {
                return Ok(_actorService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetActorById(int Id)
        {
            try
            {
                return Ok(_actorService.Get(Id));
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
        public IActionResult DeleteActor(int Id)
        {
            try
            {
                _actorService.Delete(Id);
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
        public IActionResult UpdateActor(int Id, ActorRequest actor)
        {
            try
            {
                _actorService.Update(Id, actor);
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