using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Gjennomført_Service()
        {
            return View();
        }

        public IActionResult Brukere()
        {
            return View();
        }
        public IActionResult MekaniskAvd()
        {
            return View();
        }
        public IActionResult HydrauliskAvd()
        {
            return View();
        }
        public IActionResult ElektriskAvd()
        {
            return View();
        }
        public IActionResult LagerAvd()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

       public IActionResult Service_form()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}