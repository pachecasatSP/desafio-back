using desafio_back.api.Handlers.Commands;
using desafio_back.api.Models.Request;
using desafio_back.domain.Abstractions.Services;
using FluentValidation;

namespace desafio_back.api.Models.Validators
{
    public class UpdateMotorcyclePlateRequestValidator : AbstractValidator<UpdateMotorcyclePlateRequest>
    {
        private IMotorcycleService _service;

        public UpdateMotorcyclePlateRequestValidator(IMotorcycleService service)
        {
            _service = service;

            RuleFor(e => e.placa).NotEmpty().WithMessage("Não pode ser vazio.")
               .MustAsync((e, ct) => { return _service.PlateDoesNotExists(e!); }).WithMessage("Placa já está cadastrada.");
        }
    }
}

