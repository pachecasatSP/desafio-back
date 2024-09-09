using desafio_back.api.Models.Commands;
using desafio_back.domain.Abstractions.Services;
using FluentValidation;

namespace desafio_back.api.Models.Validators
{
    public class CreateMotorcycleCommandValidator : AbstractValidator<CreateMotorcycleCommand>
    {
        private IMotorcycleService _service;

        public CreateMotorcycleCommandValidator(IMotorcycleService service)
        {
            _service = service;

            RuleFor(e => e.Identificador).NotEmpty().WithMessage("Não pode ser vazio.")
                .MustAsync((e, ct) => { return _service.IdDoesNotExists(e!); }).WithMessage("Identificador já cadastrado.");

            RuleFor(e => e.Ano).GreaterThan(0).WithMessage("Não pode ser 0.");
            RuleFor(e => e.Placa).NotEmpty().WithMessage("Não pode ser vazio.")
                .MustAsync((e,ct) => { return _service.PlateDoesNotExists(e!); }).WithMessage("Esta placa já está cadastrada.");

        }

    }
}
