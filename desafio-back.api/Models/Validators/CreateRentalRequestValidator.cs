using desafio_back.api.Models.Request;
using desafio_back.domain.Abstractions.Services;
using FluentValidation;

namespace desafio_back.api.Models.Validators;

public class CreateRentalRequestValidator : AbstractValidator<CreateRentalRequest>
{
    private IDeliverymanService? _deliveryManService;
    private IMotorcycleService? _motorcycleService;
    private IRentalPlanService? _rentalPlanService;

    public CreateRentalRequestValidator(IDeliverymanService deliverymanService,
                                        IMotorcycleService motorcycleService,
                                        IRentalPlanService rentalPlanService)
    {
        _deliveryManService = deliverymanService;
        _motorcycleService = motorcycleService;
        _rentalPlanService = rentalPlanService;

        RuleFor(e => e.Entregador_id)
            .NotEmpty()
            .MustAsync((e, ct) => { return _deliveryManService!.IdExists(e!); })
            .MustAsync((e, ct) => { return DeliverymenHasACNHType(e!); }).WithMessage("Entregador_id possui dados inválidos.");

        RuleFor(e => e.Moto_id)
            .NotEmpty()
            .MustAsync((e, ct) => { return _motorcycleService!.IdExists(e!); }).WithMessage("Moto_id possui dados inválidos.");

        RuleFor(e => e.Plano)
            .NotEmpty()
            .MustAsync((e, ct) => { return _rentalPlanService!.RentalPlanExists(e!); }).WithMessage("Plano possui dados inválidos.");

        RuleFor(e => e.Data_inicio)
            .NotEmpty()
            .Equal(DateTime.Today.AddDays(1)).WithMessage("Data_inicio possui dados inválidos.");

        RuleFor(e => e.Data_previsao_termino)
            .NotEmpty()
            .MustAsync((e, data, ct) => { return IsValidForecastEndDate(e.Plano, data); }).WithMessage("Data_previsao_termino possui dados inválidos.");

        RuleFor(e => e.Data_termino).NotEmpty();

    }

    private async Task<bool> IsValidForecastEndDate(int plano, DateTime data_previsao_termino)
    {
        var term = await _rentalPlanService.RentalPlanTermInDays(plano);
        return DateTime.Today.AddDays(1).AddDays(term) == data_previsao_termino;
    }

    private async Task<bool> DeliverymenHasACNHType(string entregador_id)
    {
        var deliveryManEntity = await _deliveryManService.FirstOrDefaultAsync(x => x.Id == entregador_id);
        if (deliveryManEntity == null)
            return false;

        return await _deliveryManService.IsAllowedCNHType(deliveryManEntity.CNHType!);
    }
}
