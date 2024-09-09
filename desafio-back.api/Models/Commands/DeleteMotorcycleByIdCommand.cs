using desafio_back.domain.Models.Entities;
using MediatR;

namespace desafio_back.api.Models.Commands
{
    public record DeleteMotorcycleByIdCommand(string Identificador) : IRequest<bool>;
}
