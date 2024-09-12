using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Commands;
using MediatR;

namespace desafio_back.api.Handlers.Commands;

public class DeleteMotorcycleByIdCommandHandler : IRequestHandler<DeleteMotorcycleByIdCommand, bool>
{
    private IMotorcycleService _service;

    public DeleteMotorcycleByIdCommandHandler(IMotorcycleService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(DeleteMotorcycleByIdCommand request, CancellationToken cancellationToken)
    {
        return await _service.DeleteAsync(request.Identificador);
    }
}
