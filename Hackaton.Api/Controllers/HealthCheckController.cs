using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet()]
    public OkObjectResult Health()
    {
        return Ok("Healthy");
    }
}
