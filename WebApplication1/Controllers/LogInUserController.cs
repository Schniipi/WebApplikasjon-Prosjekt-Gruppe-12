using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DapperMariaDBDemo;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using WebApplication1.Repositories;
using WebApplication1.Tables;
using Microsoft.AspNetCore.Authentication.Cookies;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace WebApplication1.Controllers.Login
{
    public class LogInUserController : Controller
    {
        private readonly BrukerTableRepository _repository;

        public LogInUserController(BrukerTableRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(BrukerData bruker)
        {

            IEnumerable<BrukerData> sjekkPassord = _repository.ComparePassword(bruker.BrukerNavn);

            //Sjekker om passordet knyttet til brukeren, matcher passordet som blir gitt
                foreach (var brukerLogin in sjekkPassord)
                {
                    if (brukerLogin.Passord == bruker.Passord)
                    {


                        //Oppretter en claim med brukeren sin verdi
                        var claims = new List<Claim>
                        {
                            new Claim("BrukerNavn", bruker.BrukerNavn)
                        };

                        //Lager en identitet til brukeren som bruker authenticationcookie som default authentication scheme
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        //logger inn brukeren
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                        var brukerNavn = claimsPrincipal.FindFirst("BrukerNavn")?.Value;

                        HttpContext.Session.SetString("BrukerNavn", brukerNavn);

                        return View("/Views/Home/Hjemmeside.cshtml");

                    }
                
                }


            return View();
        }
    }
}



//public async Task<IActionResult> Login(FormData model)
/*
                                        

                    

                    var claimsIdentity = new ClaimsIdentity(claims, "brukerSession1");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
*/