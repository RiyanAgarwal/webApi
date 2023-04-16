using Assignment_2.Models.Request;
using Assignment_2.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment_2.Controllers
{
    [Route("api/producers")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        readonly IProducerService _producerService;
        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpPost]
        public IActionResult AddProducer([FromBody] ProducerRequest producer)
        {
            try
            {
                var createdProducerId = _producerService.Create(producer);
                return Created($"~api/producers/{createdProducerId}", createdProducerId);
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
        public IActionResult GetProducers()
        {
            try
            {
                return Ok(_producerService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetProducerById(int Id)
        {
            try
            {
                return Ok(_producerService.Get(Id));
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
        public IActionResult DeleteProducer(int Id)
        {
            try
            {
                _producerService.Delete(Id);
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
        public IActionResult UpdateProducer(int Id, ProducerRequest producer)
        {
            try
            {
                _producerService.Update(Id, producer);
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