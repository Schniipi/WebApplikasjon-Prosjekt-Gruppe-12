using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    //[Authorize(Policy = "UserOnly")]
    public class BringDataController : Controller
    {
        private readonly KundeTableRepository _repository;
        private readonly ServiceTableRepository _repositoryS;

        public BringDataController(KundeTableRepository repository, ServiceTableRepository repositoryS)
        {
            _repository = repository;
            _repositoryS = repositoryS;
        }

        //Brukes for å vise registrerte kunder på "Kommende service" siden
        public IActionResult ShowData()
        {
            var brukere = _repository.GetAll();
            return View("/Views/Home/KommendeS.cshtml", brukere);
        }

        //Brukes for å vise ordrekortene for kunder i "Pagaende Service" siden
        public IActionResult ShowCards()
        {
            var brukere = _repositoryS.GetAll();
            return View("/Views/Home/PagaendeS.cshtml", brukere);
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

