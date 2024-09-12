using AutoMapper;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.Response;
using desafio_back.domain.Queries;
using MediatR;

namespace desafio_back.api.Handlers.Queries
{
    public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, GetRentalByIdResponse>
    {
        private IRentalService _service;
        private IMapper _mapper;

        public GetRentalByIdQueryHandler(IRentalService service,
                                         IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<GetRentalByIdResponse> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _service.FirstOrDefaultAsync(x => x.Id == request.Identificador);

            if (entity == null)
                return null;

            return _mapper.Map<GetRentalByIdResponse>(entity);

        }

    }
}
