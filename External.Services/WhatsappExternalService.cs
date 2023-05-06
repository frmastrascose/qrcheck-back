using Domain.Contracts.ExternalServices;
using Domain.Models.Whatsapp;
using External.Services.Models;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace External.Services
{
    public class WhatsappExternalService : IWhatsappExternalService
    {
        private readonly IConfiguration _cofiguration;

        public WhatsappExternalService(IConfiguration cofiguration)
        {
            _cofiguration = cofiguration;
        }

        public async Task<bool> Send(WhatsappRequestModel whatsappRequestModel)
        {
            var url = _cofiguration.GetSection("WhatsappService:Endpoint").Value;
            var from = _cofiguration.GetSection("WhatsappService:From").Value ?? "experienced-drizzle";
            var apiKey = _cofiguration.GetSection("WhatsappService:ApiKey").Value;

            var whatappContent = new WhatsappContentModel
            {
                Text = whatsappRequestModel.Message
            };

            var whatappSendModel = new WhatappSendModel
            {
                From = from,
                To = $"55{whatsappRequestModel.ReceiverNumber}",
                Contents = new List<WhatsappContentModel> ( new WhatsappContentModel[] { whatappContent})
            };
            using var flurlClient = new FlurlClient();

            var response = await $"{url}"
                                   .AllowAnyHttpStatus()
                                   .WithHeader("X-API-TOKEN", $"{apiKey}")
                                   .PostJsonAsync(whatappSendModel);

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
