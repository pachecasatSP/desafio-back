using desafio_back.domain.Entities.Response;
using MediatR;

namespace desafio_back.domain.Queries
{
    public class GetAllMotorcyclesQuery : IRequest<IEnumerable<GetMotorcycleResponse>> { }
}
