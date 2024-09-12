using desafio_back.api.Models.Request;
using desafio_back.domain.Abstractions.Services;
using FluentValidation;

namespace desafio_back.api.Models.Validators
{
    public class CreateMotorcycleRequestValidator : AbstractValidator<CreateMotorcycleRequest>
    {
        private IMotorcycleService _service;

        public CreateMotorcycleRequestValidator(IMotorcycleService service)
        {
            _service = service;

            RuleFor(e => e.Identificador).NotEmpty()
                .MustAsync((e, ct) => { return _service.IdDoesNotExists(e!); }).WithMessage("dados inválidos.");

            RuleFor(e => e.Ano).GreaterThan(0).WithMessage("dados inválidos.");

            RuleFor(e => e.Modelo).NotEmpty().WithMessage("dados inválidos.");

            RuleFor(e => e.Placa).NotEmpty()
                .MustAsync((e, ct) => { return _service.PlateDoesNotExists(e!); }).WithMessage("dados inválidos.");

        }

    }
}
