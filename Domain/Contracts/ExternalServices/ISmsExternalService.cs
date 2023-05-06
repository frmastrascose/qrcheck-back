using Comtele.Sdk.Core.Resources;
using Domain.Models.Sms;

namespace Domain.Contracts.ExternalServices;

public interface ISmsExternalService
{
    Task<bool> Send(SmsRequestModel smsRequestModel);
}
