﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.Filters;

namespace WebApplication1.Controllers
{
    [AddSecurityHeaders]
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

        public IActionResult GjennomførtS()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

       public IActionResult ServiceForm()
        {
            return View();
        }

        public IActionResult NyService() 
        {
            return View();
        }
        public IActionResult Hjemmeside()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PågåendeS() 
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
