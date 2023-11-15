using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.FormDataMappe;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class BringDataController : Controller
    {
        private readonly ServiceModelRepository _repository;

        public BringDataController(ServiceModelRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowData()
        {
            var brukere = _repository.GetAll();
            return View("/Views/Home/ServiceForm.cshtml", brukere);
        }
    }
}

