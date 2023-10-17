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

        public IActionResult NyAvd()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}