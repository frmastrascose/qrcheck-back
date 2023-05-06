using Domain.Contracts.Services;
using Domain.Models.Sms;
using Domain.Models.Whatsapp;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/notifications")]
public class NotificationController : Controller
{
    private readonly ISmsService _smsService;
    private readonly IWhatsappService _whatsappService;

    public NotificationController(ISmsService smsService, IWhatsappService whatsappService)
    {
        _smsService = smsService;
        _whatsappService = whatsappService;
    }

    [HttpPost("send-sms")]
    public async Task<IActionResult> SendSms(SmsRequestModel smsRequestModel)
    {
        await _smsService.Send(smsRequestModel);
        return NoContent();
    }

    [HttpPost("send-whatsapp")]
    public async Task<IActionResult> SendWhatsapp(WhatsappRequestModel whatsappRequestModel)
    {
        await _whatsappService.Send(whatsappRequestModel);
        return NoContent();
    }
}
