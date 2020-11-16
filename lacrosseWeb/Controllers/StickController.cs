using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using lacrosseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace lacrosseWeb.Controllers
{
    public class StickController : Controller
    {
        private const string url = "http://localhost:44334/";
        private Customer customer;
        private Manager manager;

        public IActionResult Details(int id)
        {
            customer = HttpContext.Session.GetObject<Customer>("Customer");
            manager = HttpContext.Session.GetObject<Manager>("Manager");
            if (customer == null)
            {
                Log.Error("Customer session not found");
                return RedirectToAction("Login", "Home");
            }
            if (manager == null)
            {
                Log.Error("Manager session not found");
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync($"stick/get?Id={id}");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        Log.Information($"Successfully got stick: {id}");
                        var prod = JsonConvert.DeserializeObject<Stick>(jsonString.Result);
                        return View(prod);
                    }
                }
            }
            Log.Error($"Unsuccessfully got stick: {id}");
            return View();
        }
    }
}
