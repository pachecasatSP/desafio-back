using desafio_back.api.Models.Request;
using FluentValidation;

namespace desafio_back.api.Models.Validators;

public class CreateRentalReturnRequestValidator : AbstractValidator<CreateRentalReturnRequest>
{
    public CreateRentalReturnRequestValidator()
    {
        RuleFor(e => e.Data_devolucao)
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("A data de devolução precisa estar no futuro.");
    }
}
