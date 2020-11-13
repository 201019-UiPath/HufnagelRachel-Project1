using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lacrosseWeb.Controllers
{
    public class StickController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
