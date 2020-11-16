using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lacrosseWeb.Models;
using lacrosseWeb.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace lacrosseWeb.Controllers
{
    public class ManagerController : Controller
    {
        private const string url = "http://localhost:44387/";
        private Manager manager;
        private readonly IConfiguration config;
        private readonly AlertServices alertServices;

        public ManagerController(IConfiguration config, AlertServices alertServices)
        {
            this.config = config;
            this.alertServices = alertServices;
        }

        public IActionResult GetInventory(int locId)
        {
            manager = HttpContext.Session.GetObject<Manager>("Manager");
            if (manager == null)
            {
                Log.Error("Manager session not found");
                return RedirectToAction("LoginM", "Home");
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
                        Log.Information("Successfully got locations");
                        foreach (var l in locations)
                        {
                            locationOptions.Add(new SelectListItem { Selected = false, Text = $"{l.StoreLocation}", Value = l.Id.ToString() });
                        }
                        ViewBag.locationOptions = locationOptions;
                    }
                    response = client.GetAsync($"inventory/get/{locId}");
                    response.Wait();
                    result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        Log.Information($"Successfully got inventory for location: {locId}");
                        var model = JsonConvert.DeserializeObject<List<Inventory>>(jsonString.Result);
                        return View(model);
                    }
                }
            }
            Log.Error("State is not valid");
            return View();
        }

        [HttpGet]
        public IActionResult EditInventory(int locId, int stickId)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync($"inventory/get/{locId}/{stickId}");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        var model = JsonConvert.DeserializeObject<Inventory>(jsonString.Result);
                        Log.Information($"Successfully got inventory: {locId} - {stickId}");
                        return View(model);
                    }
                }
            }
            Log.Error("State is not valid");
            return View();
        }

        [HttpPost]
        public IActionResult EditInventory(Inventory inventory)
        {
            manager = HttpContext.Session.GetObject<Manager>("Manager");
            if (manager == null)
            {
                Log.Error("Manager session not found");
                return RedirectToAction("LoginM", "Home");
            }
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var json = JsonConvert.SerializeObject(inventory);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = client.PutAsync("inventory/update", data);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        alertServices.Success("Successfully updated inventory");
                        Log.Information($"Successfully updated inventory: {json}");
                        return RedirectToAction("GetInventory", new { locationId = 1 });
                    }
                    alertServices.Danger("Something went wrong");
                    Log.Error($"Unsuccessfully updated inventory item: {json}");
                }
            }
            Log.Error("ModelState is not valid");
            return RedirectToAction("GetInventory", new { locationId = 1 });
        }

        /*
        [HttpGet]
        public IActionResult ViewInventory(string search)
        {
            string apikey = config.GetConnectionString("GiantBombAPI");
            var giantBomb = new GiantBombRestClient(apikey);
            if (!String.IsNullOrEmpty(searchString))
            {
                var results = giantBomb.SearchForAllGames(searchString);
                Log.Information("Successfully got inventory items");
                return View(results);
            }
            return View(new List<GiantBomb.Api.Model.Game>());
        }
        */
    }
}
