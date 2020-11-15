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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        [HttpPut("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddOrder(Orders order)
        {
            try
            {
                orderServices.AddOrder(order);
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateOrder(Orders order)
        {
            try
            {
                orderServices.UpdateOrder(order);
                return CreatedAtAction("UpdateOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrder(Orders order)
        {
            try
            {
                orderServices.DeleteOrder(order);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //get orders by date: desc, asc, price: desc, asc
    }
}
