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
        private readonly ProductServices productServices;

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

        [HttpPost("delete")]
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

        [HttpPost("get")]
        [Produces("application/json")]
        public IActionResult GetAllSticks()
        {
            return 1;
        }
    }
}
