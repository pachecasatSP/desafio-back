using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Commands;
using MediatR;

namespace desafio_back.api.Handlers.Commands;

public class SendDriverLicenseForDeliveryManCommandHandler : IRequestHandler<SendDriverLicenseForDeliveryManCommand, bool>
{
    private IDeliverymanService _service;

    public SendDriverLicenseForDeliveryManCommandHandler(IDeliverymanService service) =>
        _service = service;
    public async Task<bool> Handle(SendDriverLicenseForDeliveryManCommand request, CancellationToken cancellationToken)
    {
        var entity = await _service.FirstOrDefaultAsync(x => x.Id == request.Identificador)
                   ?? throw new ArgumentException($"O entregador com o identificador: {request.Identificador} não foi encontrado.");

        return await _service.SaveDriverLicenseImageAsync(request.DriverlicenseImage, entity.InternalId);
    }
}
