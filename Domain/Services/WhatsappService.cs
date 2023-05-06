using Domain.Contracts.ExternalServices;
using Domain.Contracts.Services;
using Domain.Exceptions;
using Domain.Models.Whatsapp;

namespace Domain.Services
{
    public class WhatsappService : IWhatsappService
    {
        private readonly IWhatsappExternalService _whatsappExternalService;

        public WhatsappService(IWhatsappExternalService whatsappExternalService)
        {
            _whatsappExternalService = whatsappExternalService;
        }


        public async Task Send(WhatsappRequestModel whatsappRequestModel)
        {
           var success =  await _whatsappExternalService.Send(whatsappRequestModel);

            if (success)
            {
                Console.WriteLine("A mensagem whatsapp foi enviada com sucesso.");
            }
            else
            {
                throw new DomainException("A mensagem de whatsapp pode ser enviada");
            }
        }
    }
}
