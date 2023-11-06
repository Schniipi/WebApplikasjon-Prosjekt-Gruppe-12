
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.FormDataMappe.ServiceModel;



namespace WebApplication1.Controllers.DefaultVerdierController
{
    public class DefaultVerdierController : Controller
    {

        [HttpGet]
        public IActionResult KommendeS()
        {

            var model = new FormData
            {

                Navn = "default",
                TelefonNummer = 97472745,
                Kommentar = "default kommentar"
            };

            return View("/Views/Home/ServiceForm.cshtml", model);
        }

        [HttpGet]
        public IActionResult GjennomførtS()
        {

            var model = new FormData
            {

                Navn = "default",
                TelefonNummer = 97472745,
                Kommentar = "default kommentar"
            };

            return View("/Views/Home/GjennomførtS.cshtml", model);
        }

        [HttpGet]
        public IActionResult PågåendeS()
        {

            var model = new FormData
            {

                Navn = "default",
                TelefonNummer = 97472745,
                Kommentar = "default kommentar"
            };

            return View("/Views/Home/PågåendeS.cshtml", model);
        }


    }

}