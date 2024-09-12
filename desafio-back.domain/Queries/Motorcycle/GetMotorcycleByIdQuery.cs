using desafio_back.domain.Entities.DomainEntities;
using desafio_back.domain.Entities.Response;
using MediatR;

namespace desafio_back.domain.Queries
{
    public record GetMotorcycleByIdQuery(string Identificador) : IRequest<GetMotorcycleResponse>;
}
