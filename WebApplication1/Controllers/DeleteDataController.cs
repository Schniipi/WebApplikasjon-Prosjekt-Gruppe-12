using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.FormDataMappe;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class DeleteDataController : Controller
    {
        private readonly ServiceModelRepository _repository;

        public DeleteDataController(ServiceModelRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(FormData model)
        {
            _repository.Remove(model);
            return View("/Views/Home/Hjemmeside.cshtml");
        }
    }
}

