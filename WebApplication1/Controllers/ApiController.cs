
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Filters;
using WebApplication1.Models.FormDataMappe.ServiceModel;

namespace WebApplication1.Controllers.ApiController

{
    [AddSecurityHeaders]
    public class ApiController : Controller
    {


        [HttpGet]
        public IActionResult ServiceForm()
        {

            var model = new FormData
            {

                Navn = "hei",
                TelefonNummer = 97472745,
            };

            return View(model);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Save(FormData model)
        {

            return View("/Views/Home/GjennomfortService.cshtml", model);
        }
    }
 }
