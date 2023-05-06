using Domain.Contracts.ExternalServices;
using Domain.Contracts.Services;
using Domain.Exceptions;
using Domain.Models.Sms;

namespace Domain.Services
{
    public class SmsService : ISmsService
    {
        private readonly ISmsExternalService _smsExternalService;

        public SmsService(ISmsExternalService smsExternalService)
        {
            _smsExternalService = smsExternalService;
        }


        public async Task Send(SmsRequestModel smsRequestModel)
        {
            var success = await _smsExternalService.Send(smsRequestModel);

            if (success)
            {
                Console.WriteLine("A mensagem  sms foi enviada com sucesso.");
            }
            else
            {
                throw new DomainException("A mensagem não pode ser enviada.");
            }
        }
    }
}
