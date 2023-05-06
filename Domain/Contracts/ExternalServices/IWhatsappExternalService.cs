using Comtele.Sdk.Core.Resources;
using Domain.Models.Whatsapp;

namespace Domain.Contracts.ExternalServices;

public interface IWhatsappExternalService
{
    Task<bool> Send(WhatsappRequestModel smsRequestModel);
}
