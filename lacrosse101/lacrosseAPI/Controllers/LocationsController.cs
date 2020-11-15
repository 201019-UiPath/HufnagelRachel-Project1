using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lacrosseDB.Models;
using lacrosseLib;

namespace lacrosseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationServices locationServices;

        public LocationsController(ILocationServices locationServices)
        {
            this.locationServices = locationServices;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLocation(Locations location)
        {
            try
            {
                locationServices.AddLocation(location);
                return CreatedAtAction("AddLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLocation(Locations location)
        {
            try
            {
                locationServices.UpdateLocation(location);
                return CreatedAtAction("UpdateLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLocation(Locations location)
        {
            try
            {
                locationServices.DeleteLocation(location);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(locationServices.GetAllLocations());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
