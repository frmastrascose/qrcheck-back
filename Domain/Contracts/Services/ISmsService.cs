using Domain.Models.Sms;

namespace Domain.Contracts.Services;

public interface ISmsService
{
    Task Send(SmsRequestModel smsRequestModel);
}
