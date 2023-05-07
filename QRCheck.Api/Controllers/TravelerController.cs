using Domain.Contracts.Services;
using Domain.Models;
using Domain.Models.Test;
using Microsoft.AspNetCore.Mvc;


namespace Hackaton.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class TravelerController : Controller
{
    private readonly ITravelerService _travelerService;

    public TravelerController(ITravelerService userService)
    {
        _travelerService = userService;
    }

    [HttpGet("all-active")]
    public async Task<IActionResult> GetAllActive()
    {
        var result = await _travelerService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TravelerRequestModel userRequestModel)
    {
        var result = await _travelerService.Create(userRequestModel);
        return Ok(new BaseResponse(result));
    }
}
