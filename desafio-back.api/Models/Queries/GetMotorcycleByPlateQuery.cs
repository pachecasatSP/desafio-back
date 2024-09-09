using desafio_back.domain.Models.Entities;
using MediatR;

namespace desafio_back.api.Models.Queries
{
    public record GetMotorcycleByPlateQuery(string Placa) : IRequest<Motorcycle>;
}
