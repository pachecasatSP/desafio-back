using MediatR;

namespace desafio_back.api.Handlers.Commands
{
    public record UpdateMotorcyclePlateCommand(string oldPlate, string newPlate) : IRequest<bool>;
}
