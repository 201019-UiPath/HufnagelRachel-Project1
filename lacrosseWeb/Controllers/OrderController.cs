using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using lacrosseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NpgsqlTypes;
using Serilog;

namespace lacrosseWeb.Controllers
{
    public class OrderController : Controller
    {
        private const string url = "http://localhost:44334/";
        private Customer customer;

        public IActionResult GetReceipt(Order order)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync($"order/get/{order.Id}");
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<Order>(result.Result);
                        Log.Information($"Successfully got order: {order.Id}");
                        return View(model);
                    }
                    Log.Error($"Unsuccessfully got order: {order.Id}");
                    return RedirectToAction("GetCart", "Customer");
                }
            }
            Log.Error("Unsuccessfully in getting a receipt");
            return RedirectToAction("GetCart", "Customer");
        }

        public IActionResult AddOrder(Cart cart)
        {
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            if (customer == null)
            {
                Log.Error("Customer session was not found");
                return RedirectToAction("LoginC", "Home");
            }
            if (ModelState.IsValid)
            {
                Order order = new Order();
                order.totalCost = cart.totalCost;
                order.locationId = customer.locationId;
                order.dateOfOrder = DateTime.Now;
                NpgsqlDateTime npgsqlDateTime = order.dateOfOrder; 
                order.custId = customer.Id;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var json = JsonConvert.SerializeObject(order);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("order/add", data);
                    response.Wait();
                    while (response.Result.IsSuccessStatusCode)
                    {
                        response = client.GetAsync($"order/get?dateTime={npgsqlDateTime}");
                        response.Wait();
                        var result = response.Result.Content.ReadAsStringAsync();
                        var newOrder = JsonConvert.DeserializeObject<Order>(result.Result);
                        Log.Information($"Successfully created order: {newOrder.Id}");
                        order.Id = newOrder.Id;
                        foreach (var item in customer.cart.cartItems)
                        {
                            Stick stick = item.stick;
                            LineItem lineItem = new LineItem();
                            lineItem.orderId = order.Id;
                            lineItem.stickId = item.stickId;
                            lineItem.cost = stick.cost;
                            lineItem.quantity = item.quantity;
                            json = JsonConvert.SerializeObject(lineItem);
                            data = new StringContent(json, Encoding.UTF8, "application/json");
                            response = client.PostAsync("lineitem/add", data);
                            response.Wait();
                            Log.Information($"Successfully create lineItem: {json}");
                            response = client.GetAsync($"inventory/get/{customer.locationId}/{item.stickId}");
                            response.Wait();
                            result = response.Result.Content.ReadAsStringAsync();
                            var inventoryItem = JsonConvert.DeserializeObject<Inventory>(result.Result);
                            inventoryItem.quantity -= item.quantity;
                            json = JsonConvert.SerializeObject(inventoryItem);
                            data = new StringContent(json, Encoding.UTF8, "application/json");
                            response = client.PutAsync("inventory/update", data);
                            response.Wait();
                            Log.Information($"Successfully updated inventoryItem: {json}");
                        }
                        customer.cart.cartItems.Clear();
                        HttpContext.Session.SetObject("Customer", customer);
                        return RedirectToAction("GetReceipt", order);
                    }
                }
            }
            Log.Error("Unable to create a new order");
            return RedirectToAction("GetInventory", "Customer");
        }

        public IActionResult GetOrderHistory(string sortBy, int locId)
        {
            ViewBag.SortOptions = new List<SelectListItem>()
            {
                new SelectListItem { Selected = false, Text = "Date (Lowest to Highest)", Value = ("date_asc")},
                new SelectListItem { Selected = false, Text = "Date (Highest to Lowest)", Value = ("date_asc")},
                new SelectListItem { Selected = false, Text = "Price (Lowest to Highest)", Value = ("cost_asc")},
                new SelectListItem { Selected = false, Text = "Price (Highest to Lowest)", Value = ("cost_desc")}
                
            };
            ViewBag.Locations = new List<Location>();
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            if (customer == null)
            {
                Log.Error("Customer session not found");
                return RedirectToAction("LoginC", "Home");
            }
            if (ModelState.IsValid)
            {
                // Get order history
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    string apiCall = $"order/get/customer?Id={customer.Id}";
                    var response = client.GetAsync(apiCall);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Log.Information($"Successfully got order history for {customer.email}");
                        var data = response.Result.Content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<List<Order>>(data.Result).OrderBy(x => x.Id);
                        switch (sortBy)
                        {
                            case "date_asc":
                                model = JsonConvert.DeserializeObject<List<Order>>(data.Result).OrderBy(x => x.dateOfOrder);
                                break;
                            case "date_desc":
                                model = JsonConvert.DeserializeObject<List<Order>>(data.Result).OrderByDescending(x => x.dateOfOrder);
                                break;
                            case "cost_asc":
                                model = JsonConvert.DeserializeObject<List<Order>>(data.Result).OrderBy(x => x.totalCost);
                                break;
                            case "cost_desc":
                                model = JsonConvert.DeserializeObject<List<Order>>(data.Result).OrderByDescending(x => x.totalCost);
                                break;
                            
                            default:
                                break;
                        }
                        response = client.GetAsync("location/getAll");
                        response.Wait();
                        result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var jsonString = result.Content.ReadAsStringAsync();
                            jsonString.Wait();
                            var locations = JsonConvert.DeserializeObject<List<Location>>(jsonString.Result);
                            ViewBag.Locations = locations;
                            Log.Information("Succesfully got locations");
                        }
                        return View(model);
                    }
                    Log.Error("Unsuccessfully got order history");
                    return RedirectToAction("GetInventory", "Customer");
                }
            }
            Log.Error("ModelState is invalid for GetOrderHistory");
            return RedirectToAction("GetInventory", "Customer");
        }
    }
}
