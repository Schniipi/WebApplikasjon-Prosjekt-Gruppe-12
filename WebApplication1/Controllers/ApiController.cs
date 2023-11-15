
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Filters;
using WebApplication1.Models.Tables;

namespace WebApplication1.Controllers.ApiController

{
    public class ApiController : Controller

    {
        private readonly KundeTableModelRepository _repository;

        public ApiController(KundeTableModelRepository repository){
            _repository = repository;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(KundeData model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                return View("/Views/Home/Hjemmeside.cshtml");
            }

            return View("/Views/Home/Hjemmeside.cshtml", model);
        }
    }
 }
