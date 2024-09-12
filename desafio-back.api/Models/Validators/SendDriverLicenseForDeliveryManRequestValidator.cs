using desafio_back.api.Models.Request;
using desafio_back.domain.Abstractions.Services;
using FluentValidation;

namespace desafio_back.api.Models.Validators
{
    public class SendDriverLicenseForDeliveryManRequestValidator : AbstractValidator<SendDriverLicenseForDeliveryManRequest>
    {
        private IDeliverymanService _service;

        public SendDriverLicenseForDeliveryManRequestValidator(IDeliverymanService service)
        {
            _service = service;

            RuleFor(e => e.Imagem_cnh)
                .NotEmpty().WithMessage("É necessário enviar uma imagem.")
                .MustAsync((e, ct) => _service.IsAllowedCnhImageFormat(Convert.FromBase64String(e!))).WithMessage("O formato da imagem é inválido.");
        }

    }
}
