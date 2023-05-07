using Microsoft.AspNetCore.Mvc;



namespace Hackaton.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/travel")]

    public class TravelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
