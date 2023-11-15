using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Tables;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class DeleteDataController : Controller
    {
        private readonly KundeTableModelRepository _repository;

        public DeleteDataController(KundeTableModelRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(KundeData model)
        {
            _repository.Remove(model);
            return View("/Views/Home/Hjemmeside.cshtml");
        }
    }
}

