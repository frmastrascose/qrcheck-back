using Microsoft.AspNetCore.Mvc;

namespace Hackaton.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/tests")]
public class TestController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Ok");
    }
}
