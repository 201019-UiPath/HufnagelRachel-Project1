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
    public class LineItemController : ControllerBase
    {
        public readonly IlineItemServices lineItemServices;

        public LineItemController(IlineItemServices lineItemServices)
        {
            this.lineItemServices = lineItemServices;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLineItem(lineItem lineItem)
        {
            try
            {
                lineItemServices.AddLineItem(lineItem);
                return CreatedAtAction("AddLineItem", lineItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLineItem(lineItem lineItem)
        {
            try
            {
                lineItemServices.UpdateLineItem(lineItem);
                return CreatedAtAction("UpdateLineItem", lineItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLineItem(lineItem lineItem)
        {
            try
            {
                lineItemServices.DeleteLineItem(lineItem);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
