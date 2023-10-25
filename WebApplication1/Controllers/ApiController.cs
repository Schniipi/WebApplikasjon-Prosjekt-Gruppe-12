
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Filters;
using WebApplication1.Models.FormDataMappe.ServiceModel;

namespace WebApplication1.Controllers.ApiController

{
    [AddSecurityHeaders]
    public class ApiController : Controller
    {
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Save(FormData model)
        {

            return View("/Views/Home/ServiceForm.cshtml", model);
        }
    }
 }
