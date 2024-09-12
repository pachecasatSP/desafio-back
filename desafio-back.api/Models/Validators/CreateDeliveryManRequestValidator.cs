using desafio_back.api.Models.Request;
using desafio_back.domain.Abstractions.Services;
using FluentValidation;

namespace desafio_back.api.Models.Validators;

public class CreateDeliveryManRequestValidator : AbstractValidator<CreateDeliveryManRequest>
{
    private IDeliverymanService? _service;

    public CreateDeliveryManRequestValidator(IDeliverymanService service)
    {

        _service = service;

        RuleFor(e => e.Nome).NotNull().WithMessage("É necessário informar um nome.");
        RuleFor(e => e.DataNascimento).NotNull().WithMessage("É necessário informar a data de nascimento.");
        RuleFor(e => e.NumeroCnh).NotNull().WithMessage("É necessário informar o número da CNH.");
        RuleFor(e => e.TipoCnh).NotNull().WithMessage("É necessário informar o tipo da CNH.");

        RuleFor(e => e.Identificador).NotEmpty().WithMessage("Não pode ser vazio.")
              .MustAsync((e, ct) => { return _service!.IdDoesNotExists(e!); }).WithMessage("Identificador já cadastrado.");

        RuleFor(e => e.Cnpj)
            .MustAsync((e, ct) => _service!.IsValidCnpj(e!)).WithMessage("Cnpj não é válido.");

        RuleFor(e => e.Cnpj)
            .MustAsync((e, ct) => _service!.CnpjDoesNotExists(e!)).WithMessage("CNPJ já está cadastrado.");

        RuleFor(e => e.NumeroCnh)
            .MustAsync((e, ct) => _service!.DriverLicenseDoesNotExits(e!)).WithMessage("CNH já está cadastrada");

        RuleFor(e => e.TipoCnh)
            .MustAsync((e, ct) => _service!.IsAllowedCNHType(e!)).WithMessage("Tipo de CNH não é permitido.");
    }
}
