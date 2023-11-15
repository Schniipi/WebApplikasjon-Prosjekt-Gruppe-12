using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Tables;
using Dapper;
using DapperMariaDBDemo;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace WebApplication1.Controllers.Login
{
    public class LogInUserController : Controller
    {
        private readonly BrukerTableModelRepository _repository;

        public LogInUserController(BrukerTableModelRepository repository)
        {
            _repository = repository;
        }

        //Skjuler BrukerNavn og BrukerPassord fra 'Request Data' inne i 'Network' tabben
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(BrukerData bruker)
        {

            IEnumerable<BrukerData> formDataList = _repository.GetAll();

            //Leser igjennom registrerte brukere i databasen
            foreach (var data in formDataList)
            {
                //sammenligner bruker id der med inntastet id for å sende bruker videre eller ikke
                if ((data.BrukerNavn == bruker.BrukerNavn) & (data.BrukerPassord == bruker.BrukerPassord)) {

                    var claims = new List<Claim>
                    {
                        new Claim("BrukerNavn", data.BrukerNavn)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Login");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    return View("/Views/Home/Hjemmeside.cshtml");
                }

            }

            return View();


        }
    }
}



//public async Task<IActionResult> Login(FormData model)
/*

*/