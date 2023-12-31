﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

        public IActionResult GjennomfortS()
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

        [Authorize(Policy = "UserOnly")]
        public IActionResult NyKunde() 
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

        public IActionResult PagaendeS() 
        {
            return View();
        }

        public IActionResult RegistrerBruker()
        {
            return View();
        }

        public IActionResult ServiceSkjema()
        {
            return View();
        }

        public IActionResult ServiceData()
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
