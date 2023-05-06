using Domain.Contracts.Services;
using Domain.Models;
using Domain.Models.Test;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("all-active")]
    public async Task<IActionResult> GetAllActive()
    {
        var result = await _userService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserRequestModel userRequestModel)
    {
        var result = await _userService.Create(userRequestModel);
        return Ok(new BaseResponse(result));
    }
}
