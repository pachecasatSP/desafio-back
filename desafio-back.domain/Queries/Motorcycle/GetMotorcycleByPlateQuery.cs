using desafio_back.domain.Entities.DomainEntities;
using MediatR;

namespace desafio_back.domain.Queries
{
    public record GetMotorcycleByPlateQuery(string Placa) : IRequest<Motorcycle>;
}
