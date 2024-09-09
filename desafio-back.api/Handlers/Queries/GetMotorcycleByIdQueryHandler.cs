using desafio_back.api.Models.Queries;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Models.Entities;
using MediatR;

namespace desafio_back.api.Handlers.Queries
{
    public class GetMotorcycleByIdQueryHandler : IRequestHandler<GetMotorcycleByIdQuery, Motorcycle>
    {
        private IMotorcycleService _service;
        public GetMotorcycleByIdQueryHandler(IMotorcycleService service)
        {
            _service = service;
        }

        public Task<Motorcycle> Handle(GetMotorcycleByIdQuery request, CancellationToken cancellationToken)
        {
            return _service.FirstOrDefaultAsync(x => x.Identificador == request.Identificador); 
        }
    }
}
