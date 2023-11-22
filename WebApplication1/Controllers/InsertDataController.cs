
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Filters;
using WebApplication1.Repositories;
using WebApplication1.Tables;

namespace WebApplication1.Controllers.ApiController

{
    public class InsertDataController : Controller

    {
        private readonly KundeTableRepository _repository;
        private readonly ServiceTableRepository _repositoryS;

        public InsertDataController(KundeTableRepository repository, ServiceTableRepository repositoryS){
            _repository = repository;
            _repositoryS = repositoryS;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "UserOnly")]
        public IActionResult Save(KundeData model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                return View("/Views/Home/Hjemmeside.cshtml");

            }

            return View("/Views/Home/Hjemmeside.cshtml", model);
        }

        [HttpPost]
        public IActionResult SaveService(ServiceData Service, string KundeID)
        {

            //legger all ServiceDataen i tillegg til KundeID inn i table Service
            _repositoryS.Insert(Service, KundeID);
            return View("/Views/Home/GjennomfortS.cshtml");
        }
    }
 }
