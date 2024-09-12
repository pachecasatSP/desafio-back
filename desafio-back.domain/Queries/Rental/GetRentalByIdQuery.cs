using desafio_back.domain.Entities.Response;
using MediatR;

namespace desafio_back.domain.Queries
{
    public record GetRentalByIdQuery(string Identificador) : IRequest<GetRentalByIdResponse>;
}
