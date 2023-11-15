
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Filters;
using WebApplication1.Models.Tables;



namespace WebApplication1.Controllers.DefaultVerdierController
{
    public class DefaultVerdierController : Controller
    {

        [HttpGet]
        public IActionResult KommendeS()
        {

            var model = new KundeData
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

            var model = new KundeData
            {

                Navn = "default",
                TelefonNummer = 97472745,
                Kommentar = "default kommentar"
            };

            return View("/Views/Home/GjennomførtS.cshtml", model);
        }

        [HttpGet]
        public IActionResult PagaendeS()
        {

            var model = new KundeData
            {

                Navn = "default",
                TelefonNummer = 97472745,
                Kommentar = "default kommentar"
            };

            return View("/Views/Home/Hjemmeside.cshtml", model);
        }


    }

}