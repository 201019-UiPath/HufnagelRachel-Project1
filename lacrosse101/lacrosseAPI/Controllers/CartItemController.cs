using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lacrosseDB.Models;
using lacrosseLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lacrosseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemServices cartItemServices;

        public CartItemController(ICartItemServices cartItemServices)
        {
            this.cartItemServices = cartItemServices;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCartItem(CartItem cartItem)
        {
            try
            {
                cartItemServices.AddCartItem(cartItem);
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
        public IActionResult UpdateCartItem(CartItem cartItem)
        {
            try
            {
                cartItemServices.UpdateCartItem(cartItem);
                return CreatedAtAction("UpdateCartItem", cartItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCartItem(CartItem cartItem)
        {
            try
            {
                cartItemServices.DeleteCartItem(cartItem);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
