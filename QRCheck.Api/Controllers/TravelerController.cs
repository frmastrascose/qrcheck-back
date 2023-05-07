using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Models;
using Domain.Models.Traveler;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Hackaton.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/travelers")]
public class TravelerController : Controller
{
    private readonly ITravelerService _travelerService;

    public TravelerController(ITravelerService userService)
    {
        _travelerService = userService;
    }

    [HttpGet("by-id")]
    public async Task<IActionResult> GetById([FromQuery] string id)
    {
        var result = await _travelerService.GetById(id);
        return Ok(result);
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

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TravelerEntity travelerEntity, [FromQuery] string id, [FromQuery] bool sendConfirmation = false)
    {
        travelerEntity.Id = ObjectId.Parse(id);
        await _travelerService.Update(travelerEntity, sendConfirmation);
        return NoContent();
    }
}
