using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Services;
using Domain.Contracts.ExternalServices;
using Domain.Models.Sms;
using Domain.Models.Whatsapp;
using Domain.Utils;
using External.Services.Models;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace External.Services
{
    public class SmsExternalService: ISmsExternalService
    {
        private readonly IConfiguration _cofiguration;

        public SmsExternalService(IConfiguration cofiguration)
        {
            _cofiguration = cofiguration;
        }

        public async Task<bool> Send(SmsRequestModel whatsappRequestModel)
        {
            var url = _cofiguration.GetSection("SmsService:Endpoint").Value;
            var from = _cofiguration.GetSection("SmsService:From").Value ?? "experienced-drizzle";
            var apiKey = _cofiguration.GetSection("SmsService:ApiKey").Value;

            var smsContent = new SmsContentModel
            {
                Text = whatsappRequestModel.Message
            };

            var smsSendModel = new SmsSendModel
            {
                From = from,
                To = $"55{whatsappRequestModel.ReceiverNumber}",
                Contents = new List<SmsContentModel>(new SmsContentModel[] { smsContent })
            };
            using var flurlClient = new FlurlClient();

            var response = await $"{url}"
                                   .AllowAnyHttpStatus()
                                   .WithHeader("X-API-TOKEN", $"{apiKey}")
                                   .PostJsonAsync(smsSendModel);

            if (response.ResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
