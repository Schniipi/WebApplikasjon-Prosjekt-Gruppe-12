namespace WebApplication1.Models.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class AddSecurityHeadersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            // Add the X-XSS-Protection header
            response.Headers.Add("X-XSS-Protection", "1; mode=block");

            // Add other security headers as needed
            response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval';");
            response.Headers.Add("X-Frame-Options", "DENY");
            response.Headers.Add("X-Content-Type-Options", "nosniff");
            response.Headers.Add("Referrer-Policy", "no-referrer");
            response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
        }
    }
}


