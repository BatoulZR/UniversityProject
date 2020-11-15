using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeniorProject.Models;

namespace SeniorProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PermissionsList()
        {
            return View();
        }

        public IActionResult RequestsPage()
        {
            return View();
        }

        public IActionResult adminHome()
        {
            return View();
        }

        public IActionResult HomePage1()
        {
            return View();
        }

        public IActionResult PHDstudentHome()
        {
            return View();
        }

        public IActionResult assistantHome()
        {
            return View();
        }

        public IActionResult traineeHome()
        {
            return View();
        }

        public IActionResult PHDHome()
        {
            return View();
        }

        public IActionResult M2Home()
        {
            return View();
        }
        public IActionResult InventoriesList()
        {
            return View();
        }

        public IActionResult FreezersPage()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
