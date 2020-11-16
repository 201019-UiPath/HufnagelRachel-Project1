using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using lacrosseWeb.Features;
using lacrosseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Serilog;

namespace lacrosseWeb.Controllers
{
    public class CustomerController : Controller
    {
        private const string url = "http://localhost:44387/";
        private Customer customer;
        private AlertServices alertServices;
        public CustomerController(AlertServices alertServices)
        {
            this.alertServices = alertServices;
        }

        public IActionResult GetInventory()
        {
            Log.Information("Cust to get Inventory Menu");
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            if (customer == null)
            {
                Log.Error("Session not found");
                return RedirectToAction("LoginC", "Home");
            }
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var responce = client.GetAsync($"inventory/get/{customer.locationId}");
                    responce.Wait();
                    var result = responce.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Log.Information($"Sucess, {customer.email} got inventory at {customer.locationId}");
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        var model = JsonConvert.DeserializeObject<List<Inventory>>(jsonString.Result);
                        return View(model);
                    }
                }
            }
            Log.Error($"Failed to get inventory at {customer.locationId}");
            return View();
        }

        public IActionResult AddItemToCart(int stickId, int quantity)
        {
            Log.Information($"About to add {quantity} stick(s) with Id: {stickId}, to cart");
            Stick stick = new Stick();
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            if (customer == null)
            {
                Log.Error("Customer session not found");
                return RedirectToAction("LoginC", "Home");
            }
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync($"stick/get?Id={stickId}");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        var prod = JsonConvert.DeserializeObject<Stick>(jsonString.Result);
                        stick = prod;
                        Log.Information($"Got Stick {stick.Id}");
                    }
                }
                CartItem cartItem = new CartItem();
                cartItem.stickId = stickId;
                cartItem.quantity = quantity;
                customer.cart.totalCost += (stick.cost * quantity);
                customer.cart.cartItems.Add(cartItem);
                HttpContext.Session.SetObject("Customer", customer);
                Log.Information($"Updated {customer.email}'s session");
                alertServices.Information($"{stick.name} added to the cart.", true);
                return View("GetInventory", customer.location.inventory);
            }
            Log.Error($"State not valid {ModelState}");
            return RedirectToAction("GetInventory");
        }

        public IActionResult RemoveItemFromCart(Stick stick)
        {
            Log.Information($"About to remove {stick.Id} from cart");
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            if (customer == null)
            {
                Log.Error("Customer session not found");
                return RedirectToAction("LoginC", "Home");
            }
            if (ModelState.IsValid)
            {
                CartItem cartItem = new CartItem();
                cartItem.stick = stick;
                cartItem.stickId = stick.Id;
                cartItem.quantity = 1;
                customer.cart.cartItems.RemoveAll(ci => ci.stickId == cartItem.stickId);
                customer.cart.totalCost -= (stick.cost * cartItem.quantity);
                Log.Information($"Successfully removed item form cart: {stick.Id}");
                Log.Information($"Updated cust session data: {customer}");
                return RedirectToAction("GetCart");
            }
            Log.Error($"State is not valid {ModelState}");
            return RedirectToAction("GetInventory");
        }

        public IActionResult GetCart()
        {
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            Log.Information($"about to get cart for {customer.email}");
            if (customer == null)
            {
                Log.Information("Customer session not found");
                return RedirectToAction("LoginC", "Home");
            }
            return View(customer.cart);
        }

        public IActionResult EditCustomer()
        {
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            Log.Information($"About to get information for {customer.email}");
            if (customer == null)
            {
                Log.Error("Customer session not found");
                return RedirectToAction("LoginC", "Home");
            }
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync("location/getAll");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        var locations = JsonConvert.DeserializeObject<List<Location>>(jsonString.Result);
                        var locationOptions = new List<SelectListItem>();
                        Log.Information($"Succesfully retreived from database: {locations}");
                        foreach (var l in locations)
                        {
                            locationOptions.Add(new SelectListItem { Selected = false, Text = $"{l.StoreLocation}", Value = l.Id.ToString() });
                        }
                        ViewBag.locationOptions = locationOptions;
                        return View(customer);
                    }
                    Log.Error("Failed to make api call locations/getAll");
                }
            }
            Log.Error($"State is not valid {ModelState}");
            return RedirectToAction("GetInventory");
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer newCust)
        {
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            Log.Information($"About to get information for {customer.email}");
            if (customer == null)
            {
                Log.Error("Customer session was not found");
                return RedirectToAction("LoginC", "Home");
            }
            if (ModelState.IsValid)
            {
                newCust.location = customer.location;
                newCust.orders = customer.orders;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var json = JsonConvert.SerializeObject(newCust);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = client.PutAsync("customer/update", data);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        // Successfully edited user
                        HttpContext.Session.SetObject("Customer", newCust);
                        alertServices.Success("Succesfully updated information");
                        Log.Information($"Succesfully updated customer: {newCust}");
                        return View(newCust);
                    }
                    else
                    {
                        alertServices.Danger("Something went wrong");
                    }
                }
                return View("Get Inventory");
            }
            Log.Error($"State is not valid {ModelState}");
            return RedirectToAction("GetInventory");
        }
            
    }
}
