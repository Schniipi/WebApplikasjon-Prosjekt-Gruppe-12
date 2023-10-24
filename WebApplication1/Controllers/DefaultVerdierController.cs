
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Filters;
using WebApplication1.Models.FormDataMappe.ServiceModel;



namespace WebApplication1.Controllers.DefaultVerdierController
{
    [AddSecurityHeaders]
    public class DefaultVerdierController : Controller
    {

        [HttpGet]
        public IActionResult NewServiceDef()
        {

            var model = new FormData
            {

                Navn = "default",
                TelefonNummer = 97472745,
            };

            return View("/Views/Home/ServiceForm.cshtml", model);
        }

        [HttpGet]
        public IActionResult GjennomfortServiceDef()
        {

            var model = new FormData
            {

                Navn = "default",
                TelefonNummer = 97472745,
            };

            return View("/Views/Home/GjennomfortService.cshtml", model);
        }

        [HttpGet]
        public IActionResult PagaendeSDef()
        {

            var model = new FormData
            {

                Navn = "default",
                TelefonNummer = 97472745,
            };

            return View("/Views/Home/PagaendeS.cshtml", model);
        }


    }

}