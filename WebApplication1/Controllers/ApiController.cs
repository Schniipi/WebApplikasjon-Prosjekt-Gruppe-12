
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.FormDataMappe.ServiceModel;

namespace WebApplication1.Controllers.ApiController

{
    public class ApiController : Controller
    {
        private readonly ServiceModelRepository _repository;


        public ApiController(ServiceModelRepository repository){

            _repository = repository;

          }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Save(FormData model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                return RedirectToAction("/Views/Home/ServiceForm.cshtml");
            }
            return View("/Views/Home/Hjemmeside.cshtml");
        }
    }
 }
