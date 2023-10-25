namespace WebApplication1.Models.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class AddSecurityHeadersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            // Denne headeren instruerer nettleseren om å aktivere beskyttelse mot XSS (cross-site scripting),
            // og blokkere eventuelle oppdagede angrep.
            response.Headers.Add("X-XSS-Protection", "1; mode=block");

            // Denne headeren spesifiserer en policy for å kontrollere hvilke ressurser som kan lastes av nettleseren,
            // og bidrar til å redusere potensielle XSS-angrep.
            // Her skulle vi få inn CSP, men vi støttet på problemer der halvparten av gruppen...
            // ...ikke fikk fremvist det som ble skrevet i css og innholdet i layout.cs på grunn av denne headeren...
            // ...Derfor velger vi å ha denne som kommentar for nå, og videre finne ut av hvordan å løse dette problemet. 
            // response.Headers.Add("Content-Security-Policy","default-src,'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval';");

            // Denne headeren spesifiserer om en nettside kan vises i en iframe, noe som hjelper med å forhindre Clickjacking-angrep.
            response.Headers.Add("X-Frame-Options", "DENY");
            
            // Denne headeren forhindrer nettleseren i å tolke filer som noe annet enn den deklarerte innholdstypen,
            // noe som reduserer risikoen for innholdssniffingsangrep.
            response.Headers.Add("X-Content-Type-Options", "nosniff");

            // Denne headeren kontrollerer hvor mye referrer-informasjon som inkluderes i HTTP-hodet
            // når du navigerer fra en side til en annen.
            response.Headers.Add("Referrer-Policy", "no-referrer");

            // Denne headeren tvinger bruk av HTTPS av nettleseren, og sikrer en sikker tilkobling i en angitt periode.
            response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
        }
    }
}


