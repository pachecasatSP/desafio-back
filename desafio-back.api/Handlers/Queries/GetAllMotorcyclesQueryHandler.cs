using desafio_back.api.Models.Queries;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Models.Entities;
using MediatR;

namespace desafio_back.api.Handlers.Queries
{
    public class GetAllMotorcyclesQueryHandler : IRequestHandler<GetAllMotorcyclesQuery, IEnumerable<Motorcycle>>
    {
        private IMotorcycleService _service;

        public GetAllMotorcyclesQueryHandler(IMotorcycleService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Motorcycle>> Handle(GetAllMotorcyclesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
}
