using Domain.Models.Sms;
using Domain.Models.Whatsapp;

namespace Domain.Contracts.Services;

public interface IWhatsappService
{
    Task Send(WhatsappRequestModel whatsappRequestModel);
}
