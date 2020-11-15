using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lacrosseDB.Models;
using lacrosseLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lacrosseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StickController : ControllerBase
    {
        private readonly IProductServices productServices;

        public StickController(ProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult AddStick(Sticks stick)
        {
            try
            {
                productServices.AddStick(stick);
                return CreatedAtAction("AddStick", stick);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteStick(Sticks stick)
        {
            try
            {
                productServices.DeleteStick(stick);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateStick(Sticks stick)
        {
            try
            {
                productServices.UpdateStick(stick);
                return CreatedAtAction("UpdateStick", stick);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllSticks()
        {
            try
            {
                return Ok(productServices.GetAllSticks());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{Id}")]
        [Produces("application/json")]
        public IActionResult GetProductByStickId(int stickId)
        {
            try
            {
                return Ok(productServices.GetProductByStickId(stickId));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
