using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lacrosseWeb.Models;
using Serilog;
using System.Net.Http;
using Newtonsoft.Json;
using lacrosseWeb.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace lacrosseWeb.Controllers
{
    public class HomeController : Controller
    {
        private const string url = "http://localhost:44334/";
        private readonly ILogger<HomeController> _logger;
        public AlertServices alertServices { get; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ViewResult Login()
        {
            Log.Information("About to open LoginView");
            var model = new LoginView();
            return View(model);

        }

        [HttpPost]
        public IActionResult LoginC(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                Log.Information("About to login");
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var responce = client.GetAsync($"customer/get?email={loginView.email}");

                    responce.Wait();

                    var result = responce.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonString = result.Content.ReadAsStringAsync();

                        jsonString.Wait();

                        var verifedCustomer = JsonConvert.DeserializeObject<Customer>(jsonString.Result);
                        Log.Information($"Sucess, {verifedCustomer} information has been received");
                        if (verifedCustomer.email == loginView.email)
                        {
                            Log.Information("Customer is signing in");
                            HttpContext.Session.SetObject("Customer", verifedCustomer);
                            return RedirectToAction("GetInventory", "Customer");
                        }
                        else
                        {
                            alertServices.Danger("Invalid email or password", true);
                            Log.Error($"Unsuccessfuly login: {loginView}");
                            ModelState.AddModelError("Error", "Invalid information");
                            return View(loginView);
                        }
                    }
                    alertServices.Danger("Cannot reach server. Try again.", true);
                }
            }
            Log.Error($"State Not Valid {loginView}");
            return View(loginView);
        }

        [HttpPost]
        public IActionResult LoginM(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                Log.Information("About to login");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var responce = client.GetAsync($"manager/get?email={loginView.email}");
                    responce.Wait();

                    var result = responce.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();

                        var verifedManager = JsonConvert.DeserializeObject<Customer>(jsonString.Result);
                        Log.Information($"Sucess, {verifedManager} information has been received");
                        if (verifedManager.email == loginView.email)
                        {
                            Log.Information("Manager is signing in");
                            HttpContext.Session.SetObject("Manager", verifedManager);
                            return RedirectToAction("GetInventory", "Manager");
                        }
                        else
                        {
                            alertServices.Danger("Invalid email or password", true);
                            Log.Error($"Unsuccessfuly login: {loginView}");
                            ModelState.AddModelError("Error", "Invalid information");
                            return View(loginView);
                        }
                    }
                    alertServices.Danger("Cannot reach server. Try again.", true);
                }
            }
            Log.Error($"State Not Valid {loginView}");
            return View(loginView);
        }

        [HttpPost]
        public IActionResult SignUpC(SignupView signupView)
        {
            Log.Information($"Trying to sign up {signupView}");
            if (ModelState.IsValid)
            {
                Customer newCust = new Customer();
                newCust.FirstName = signupView.FirstName;
                newCust.LastName = signupView.LastName;
                newCust.locationId = signupView.locationId;
                newCust.email = signupView.email;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var json = JsonConvert.SerializeObject(newCust);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var responce = client.PostAsync("customer/add", data);
                    responce.Wait();

                    var result = responce.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        HttpContext.Session.SetObject("Customer", newCust);
                        Log.Information($"Succes, {newCust} added.");
                        return RedirectToAction("GetInventory", "Customer");
                    }
                }
            }
            return View(signupView);
        }

        [HttpPost]
        public IActionResult SignUpM(SignupView signupView)
        {
            Log.Information($"Trying to sign up {signupView}");
            if (ModelState.IsValid)
            {
                Manager newMan = new Manager();
                newMan.FirstName = signupView.FirstName;
                newMan.LastName = signupView.LastName;
                newMan.locationId = signupView.locationId;
                newMan.email = signupView.email;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var json = JsonConvert.SerializeObject(newMan);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var responce = client.PostAsync("manager/add", data);
                    responce.Wait();

                    var result = responce.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        HttpContext.Session.SetObject("Manager", newMan);
                        Log.Information($"Succes, {newMan} added.");
                        return RedirectToAction("GetInventory", "Manager");
                    }
                }
            }
            return View(signupView);
        }


        [HttpGet]
        public ViewResult SignUp()
        {
            Log.Information("Attemping to get SignUp View");
            var signup = new SignupView();

            if (ModelState.IsValid)
            {
                // Get list of locations
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
                        foreach (var l in locations)
                        {
                            locationOptions.Add(new SelectListItem { Selected = false, Text = $"{l.StoreLocation}", Value = l.Id.ToString() });
                        }
                        signup.locationOptions = locationOptions;
                        Log.Information("Succesfully retreived locations");
                    }
                }
                return View(signup);
            }
            Log.Error($"Model state is invalid: {ModelState.Values}");
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            Log.Information("Signing out");
            return View("Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
