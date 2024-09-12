using AutoMapper;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.Response;
using desafio_back.domain.Queries;
using MediatR;

namespace desafio_back.api.Handlers.Queries;

public class GetMotorcycleByIdQueryHandler : IRequestHandler<GetMotorcycleByIdQuery, GetMotorcycleResponse>
{
    private IMotorcycleService _service;
    private IMapper _mapper;

    public GetMotorcycleByIdQueryHandler(IMotorcycleService service,
                                         IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<GetMotorcycleResponse> Handle(GetMotorcycleByIdQuery request, CancellationToken cancellationToken)
    {
        var result = _service.FirstOrDefaultAsync(x => x.Id == request.Identificador);
        return _mapper.Map<GetMotorcycleResponse>(result);
    }
}
