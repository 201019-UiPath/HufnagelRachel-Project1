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
    public class InventController : ControllerBase
    {
        private readonly IInventoryServices inventoryServices;

        public InventController(IInventoryServices inventoryServices)
        {
            this.inventoryServices = inventoryServices;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddInventory(Inventory inventory)
        {
            try
            {
                inventoryServices.AddInventory(inventory);
                return CreatedAtAction("AddInventory", inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateInventory(Inventory inventory)
        {
            try
            {
                inventoryServices.UpdateInventory(inventory);
                return CreatedAtAction("UpdateInventory", inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteInventory(Inventory inventory)
        {
            try
            {
                inventoryServices.DeleteInventory(inventory);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}")]
        [Produces("application/json")]
        public IActionResult GetAllInventoryByLocationId(int locId)
        {
            try
            {
                return Ok(inventoryServices.GetAllOfInventoryByLocationId(locId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}/{stickId}")]
        [Produces("application/json")]
        public IActionResult GetItemByLocationIdBookId(int locationId, int stickId)
        {
            try
            {
                return Ok(inventoryServices.GetItemByLocIdStickId(locationId, stickId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
