
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Filters;
using WebApplication1.Repositories;
using WebApplication1.Tables;

namespace WebApplication1.Controllers

{
    public class InsertDataController : Controller

    {
        private readonly KundeTableRepository _repository;
        private readonly ServiceTableRepository _repositoryS;
        private readonly BrukerTableRepository _repositoryB;
        private readonly ServiceFormTableRepository _repositorySF;
        private readonly ServiceSkjemaTableRepository _repositorySS;

        public InsertDataController(KundeTableRepository repository, ServiceTableRepository repositoryS, BrukerTableRepository repositoryB, ServiceFormTableRepository repositorySF, ServiceSkjemaTableRepository repositorySS)
        {
            _repository = repository;
            _repositoryS = repositoryS;
            _repositoryB = repositoryB;
            _repositorySF = repositorySF;
            _repositorySS = repositorySS;
        }

        //Lar 'Admin' brukere registrere nye kunder
        [Authorize(Policy = "UserOnly")]
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

        //Lar bruker opprette en service på en kunde
        [HttpPost]
        public IActionResult SaveService(ServiceData Service, string KundeID)
        {

            //legger all ServiceDataen i tillegg til KundeID inn i table Service
            _repositoryS.Insert(Service, KundeID);
            return View("/Views/Home/Hjemmeside.cshtml");
        }

        //Lar 'Admin' brukere registrere nye brukere
        [Authorize(Policy = "UserOnly")]
        [HttpPost]
        public IActionResult AddUser(BrukerData bruker)
        {

            _repositoryB.LeggTilBruker(bruker);
            return View("/Views/Home/Hjemmeside.cshtml");
        }

        //Legger til kommentar for skjema på en service
        [HttpPost]
        public IActionResult SaveSkjema(ServiceSkjema service)
        {
            _repositorySS.AddSkjema(service);
            return View("/Views/Home/ServiceData.cshtml");
        }

        //Lagrer og legger til dataen fra serviceskjema. Dette er en 'ikkefullført' implementasjon
        [HttpPost]
        public IActionResult SaveServiceData //Legger til alle sjekkpunktsvar som en streng
        (
        ServiceForm data,
        string SjekkpunktSvar1, string SjekkpunktSvar2, string SjekkpunktSvar3,
        string SjekkpunktSvar4, string SjekkpunktSvar5, string SjekkpunktSvar6,
        string SjekkpunktSvar7, string SjekkpunktSvar8,

        string SjekkpunktTyper1, string SjekkpunktTyper2, string SjekkpunktTyper3,
        string SjekkpunktTyper4, string SjekkpunktTyper5, string SjekkpunktTyper6,
        string SjekkpunktTyper7, string SjekkpunktTyper8,

        string Sjekkpunkter1, string Sjekkpunkter2, string Sjekkpunkter3,
        string Sjekkpunkter4, string Sjekkpunkter5, string Sjekkpunkter6,
        string Sjekkpunkter7, string Sjekkpunkter8
        )

        {
            //Lager variabler som holder på alle verdiene. Disse skal legges inn i columns i databasen
            //Variabel for alle verdiene i sjekklisten
            string sjekkpunktValues =
            (
            $"{SjekkpunktSvar1}{SjekkpunktSvar2}{SjekkpunktSvar3}{SjekkpunktSvar4}{SjekkpunktSvar5}{SjekkpunktSvar6}{SjekkpunktSvar7}{SjekkpunktSvar8}"
            );

            //variabel for alle avdelingene i sjekklisten
            string sjekkpunktTyper =
            (
            $"{SjekkpunktTyper1}{SjekkpunktTyper2}{SjekkpunktTyper3}{SjekkpunktTyper4}{SjekkpunktTyper5}{SjekkpunktTyper6}{SjekkpunktTyper7}{SjekkpunktTyper8}"
            );

            //sjekkliste for navnet til raden
            string sjekkpunktNavn =
            (
            $"{Sjekkpunkter1}{Sjekkpunkter2}{Sjekkpunkter3}{Sjekkpunkter4}{Sjekkpunkter5}{Sjekkpunkter6}{Sjekkpunkter7}{Sjekkpunkter8}"
            );

            _repositorySF.AddServiceData(data, sjekkpunktValues, sjekkpunktTyper, sjekkpunktNavn); 
            return View("/Views/Home/Hjemmeside.cshtml");
        }
        
    }
 }
