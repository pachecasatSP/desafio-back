using AutoMapper;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.Response;
using desafio_back.domain.Queries;
using MediatR;

namespace desafio_back.api.Handlers.Queries;

public class GetAllMotorcyclesQueryHandler : IRequestHandler<GetAllMotorcyclesQuery, IEnumerable<GetMotorcycleResponse>>
{
    private IMotorcycleService _service;
    private IMapper _mapper;

    public GetAllMotorcyclesQueryHandler(IMotorcycleService service,
                                         IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetMotorcycleResponse>> Handle(GetAllMotorcyclesQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllAsync();
        return _mapper.Map<IEnumerable<GetMotorcycleResponse>>(result); 
    }
}
