using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Tables;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    //[Authorize(Policy = "UserOnly")]
    public class BringDataController : Controller
    {
        private readonly KundeTableRepository _repository;
        private readonly ServiceTableRepository _repositoryS;
        private readonly ServiceFormTableRepository _repositorySF;

        public BringDataController(KundeTableRepository repository, ServiceTableRepository repositoryS, ServiceFormTableRepository repositorySF)
        {
            _repository = repository;
            _repositoryS = repositoryS;
            _repositorySF = repositorySF;
        }

        //Brukes for å vise registrerte kunder på "Kommende service" siden
        [HttpGet]
        public IActionResult ShowData()
        {
            var brukere = _repository.GetAll();
            return View("/Views/Home/KommendeS.cshtml", brukere);
        }

        //Brukes for å vise ordrekortene for kunder i "Pagaende Service" siden
        [HttpGet]
        public IActionResult ShowCards()
        {
            var brukere = _repositoryS.GetAll();
            return View("/Views/Home/PagaendeS.cshtml", brukere);
        }

        //Viser de fullførte ordrene i "GjennomfortS" siden
        [HttpGet]
        public IActionResult ShowForm()
        {
            var brukere = _repositorySF.GetAll();

            //Converterer dataen hentet fra "ServiceData" table til en string
            return View("/Views/Home/GjennomfortS.cshtml", brukere);
        }

        //sender brukeren til "OpprettService" der en service kan opprettes i den valgte kundens ID
        public IActionResult OpprettService()
        {
            //var brukere = _repository.GetAll();

            if (HttpContext.Request.Query.TryGetValue("kundeID", out var kundeIDValue))
            {
                string kundeID = kundeIDValue.FirstOrDefault();

                ViewData["kundeID"] = kundeID;
            }

            return View("/Views/Home/OpprettService.cshtml");
        }
    }
}

