using AutoMapper;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Commands;
using desafio_back.domain.Entities.DomainEntities;
using MediatR;

namespace desafio_back.api.Handlers.Commands;

public class CreateDeliveryManCommandHandler : IRequestHandler<CreateDeliveryManCommand, DeliveryMan>
{
    private IDeliverymanService _service;
    private IMapper _mapper;

    public CreateDeliveryManCommandHandler(IDeliverymanService service,
                                           IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<DeliveryMan> Handle(CreateDeliveryManCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<DeliveryMan>(request);
            return await _service.SaveAsync(entity);
        }
        catch
        {
            throw new ArgumentException("O request de entrada não pôde ser mapeado para a entidade.");
        }
    }
}
