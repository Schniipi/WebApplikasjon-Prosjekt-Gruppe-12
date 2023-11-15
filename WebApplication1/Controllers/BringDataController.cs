using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Tables;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class BringDataController : Controller
    {
        private readonly KundeTableModelRepository _repository;

        public BringDataController(KundeTableModelRepository repository)
        {
            _repository = repository;
        }

        //Brukes for å vise registrerte kunder på "Kommende service" siden
        [Authorize(Policy = "UserOnly")]
        public IActionResult ShowData()
        {
            var brukere = _repository.GetAll();
            return View("/Views/Home/ServiceForm.cshtml", brukere);
        }

        //Brukes for å vise ordrekortene for kunder i "Pagaende Service" siden
        public IActionResult ShowCards()
        {
            var brukere = _repository.GetAll();
            return View("/Views/Home/PagaendeS.cshtml", brukere);
        }
    }
}

