using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public class PostServiceRequest {
            public required string Status { get; set;}
        }


[HttpPost]
[Route("Service")]
        public IActionResult PostService([FromBody] PostServiceRequest request) {
            return Ok(request);
        }
    }
}
