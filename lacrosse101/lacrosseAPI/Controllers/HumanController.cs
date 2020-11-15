using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lacrosseDB.Models;
using lacrosseLib;
using Microsoft.AspNetCore.Cors;

namespace lacrosseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly ICustomerServices customerServices;
        private readonly IManagerServices managerServices;
        private readonly ICartServices cartServices;
        private ValidInvalidServices validInvalidServices;

        public HumanController(IManagerServices managerServices)
        {
            this.managerServices = managerServices;
        }

        public HumanController(ICustomerServices customerServices, ICartServices cartServices)
        {
            this.customerServices = customerServices;
            this.cartServices = cartServices;
        }

        [HttpPost("addC")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult AddCustomer(Customer customer)
        {
            try
            {
                customerServices.AddCustomer(customer);
                return CreatedAtAction("AddCustomer", customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("addM")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult AddManager(Manager manager)
        {
            try
            {
                managerServices.AddManager(manager);
                return CreatedAtAction("AddManager", manager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("editC")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult EditCustomer(Customer customer)
        {
            try
            {
                customerServices.UpdateCustomer(customer);
                return CreatedAtAction("EditCustomer", customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("editM")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult EditManager(Manager manager)
        {
            try
            {
                managerServices.UpdateManager(manager);
                return CreatedAtAction("EditManager", manager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteC")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            try
            {
                customerServices.DeleteCustomer(customer);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteM")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult DeleteManager(Manager manager)
        {
            try
            {
                managerServices.DeleteManager(manager);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(customerServices.GetAllCustomers());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{email}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetCustomerByEmail(string email)
        {
            try
            {
                return Ok(customerServices.GetCustomerByEmail(email));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("signInC")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult CustSignIn(Customer customer)
        {
            try
            {
                Customer custToSignIn = customerServices.GetCustomerByEmail(customer.email);

                if (custToSignIn.email != customer.email)
                {
                    return StatusCode(403);
                }
                else
                {
                    return Ok(custToSignIn);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("signInM")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult ManSignIn(Manager manager)
        {
            try
            {
                Manager manToSignIn = managerServices.GetManagerByEmail(manager.email);

                if (manToSignIn.email != manager.email)
                {
                    return StatusCode(403);
                }
                else
                {
                    return Ok(manToSignIn);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("signUpC")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult CustSignUp(Customer customer)
        {
            try
            {
                List<Customer> custs = customerServices.GetAllCustomers();
                if (ValidInvalidServices.ValidEmail(customer.email) == false && validInvalidServices.IsUniqueEmail(customer.email, custs) == false)
                {
                    return StatusCode(409);
                }
                customerServices.AddCustomer(customer);
                Customer newCust = customerServices.GetCustomerByEmail(customer.email);
                Cart cart = new Cart();
                cart.custId = newCust.Id;
                cartServices.AddCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("signUpM")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult ManSignUp(Manager manager)
        {
            try
            {
                List<Manager> man = managerServices.GetAllManagers();
                if (ValidInvalidServices.ValidEmail(manager.email) == false && validInvalidServices.IsUniqueEmail(manager.email, man) == false)
                {
                    return StatusCode(409);
                }
                managerServices.AddManager(manager);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
