using Domain.Models.Sms;
using Domain.Models.Whatsapp;
using FluentValidation;

namespace Domain.Validators
{
    public class WhatsappRequestModelValidator : AbstractValidator<WhatsappRequestModel>
    {
        public WhatsappRequestModelValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mensagem é obrigatória");
            RuleFor(x => x.ReceiverNumber).NotEmpty().WithMessage("Destinatário é obrigatório.");
            RuleFor(x => x.Message).MaximumLength(1024).WithMessage("Mensagem deve ter no máximo 1024 caracteres");
            RuleFor(x => x.ReceiverNumber).Length(11).WithMessage("Destinatário deve ter 11 caracteres");
        }
    }
}
