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
using  Newtonsoft.Json;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace WebApplication1.Controllers
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

            bool isAdmin = _repository.GetRole(bruker.BrukerNavn);
            IEnumerable<BrukerData> sjekkPassord = _repository.ComparePassword(bruker.BrukerNavn);


            //Sjekker om passordet knyttet til brukeren, matcher passordet som blir gitt
            foreach (var brukerLogin in sjekkPassord)
            {
                var deHashPassword = new PasswordHasher<BrukerData>();

                var passwordHash = deHashPassword.VerifyHashedPassword(brukerLogin, brukerLogin.Passord, bruker.Passord);


                if (passwordHash == PasswordVerificationResult.Success)
                {

                    //Sjekker om bruker er rolle "Admin"
                    if (isAdmin)
                    {
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

                    else
                    {
                        //Utfører samme kode som istad, bare at dersom brukeren er en mekaniker, får de ikke claimet som gir adminroller
                        var claims = new List<Claim>
                        {
                            new Claim("ikkeAdmin", bruker.BrukerNavn)
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                        var brukerNavn = claimsPrincipal.FindFirst("ikkeAdmin")?.Value;

                        HttpContext.Session.SetString("ikkeAdmin", brukerNavn);

                        return View("/Views/Home/Hjemmeside.cshtml");

                    }
                }

                else if (passwordHash == PasswordVerificationResult.Failed)
                {

                    var a = TempData["HEI DER"];
                    return View("/Views/Home/Login.cshtml");
                }

            }

            return View();
        }
    }
}



