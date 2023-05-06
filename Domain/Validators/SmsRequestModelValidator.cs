using Domain.Models.Sms;
using FluentValidation;

namespace Domain.Validators
{
    public class SmsRequestModelValidator : AbstractValidator<SmsRequestModel>
    {
        public SmsRequestModelValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mensagem é obrigatória");
            RuleFor(x => x.ReceiverNumber).NotEmpty().WithMessage("Destinatário é obrigatório.");
            RuleFor(x => x.Message).MaximumLength(160).WithMessage("Mensagem deve ter no máximo 160 caracteres");
            RuleFor(x => x.ReceiverNumber).Length(11).WithMessage("Destinatário deve ter 11 caracteres");
        }
    }
}
