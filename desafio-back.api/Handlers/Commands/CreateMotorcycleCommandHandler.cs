using AutoMapper;
using desafio_back.api.Models.Commands;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Models.Entities;
using MediatR;
using Newtonsoft.Json;

namespace desafio_back.web.api.Handlers.Commands
{
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
            _logger.LogInformation(JsonConvert.SerializeObject(request));
            
            var entity = _mapper.Map<Motorcycle>(request);

            _logger.LogInformation(JsonConvert.SerializeObject(entity));
            var motorcycle = await _service.SaveAsync(entity);

            return motorcycle;
        }
    }
}
