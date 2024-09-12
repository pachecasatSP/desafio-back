using AutoMapper;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Commands;
using desafio_back.domain.Entities.DomainEntities;
using MediatR;

namespace desafio_back.api.Handlers.Commands;

public class CreateMotorcycleCommandHandler : IRequestHandler<CreateMotorcycleCommand, Motorcycle>
{
    private readonly ILogger<CreateMotorcycleCommandHandler> _logger;
    private readonly IMotorcycleService _service;
    private readonly IMapper _mapper;

    public CreateMotorcycleCommandHandler(ILogger<CreateMotorcycleCommandHandler> logger,
                                          IMotorcycleService service,
                                          IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    public async Task<Motorcycle> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Motorcycle>(request);
            var motorcycle = await _service.SaveAsync(entity);

            return motorcycle;
        }
        catch
        {
            throw new ArgumentException("O request de entrada não pôde ser mapeado para a entidade.");
        }
    }
}
