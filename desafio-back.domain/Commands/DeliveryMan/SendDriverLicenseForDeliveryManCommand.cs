using MediatR;

namespace desafio_back.domain.Commands
{
    public record SendDriverLicenseForDeliveryManCommand(string? Identificador, string? DriverlicenseImage) : IRequest<bool>;
}
