using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Commands;
using MediatR;

namespace desafio_back.api.Handlers.Commands
{
    public class CreateRentalReturnCommandHandler : IRequestHandler<CreateRentalReturnCommand, bool>
    {
        private IRentalService _service;
        private ILogger<CreateRentalReturnCommandHandler> _logger;

        public CreateRentalReturnCommandHandler(IRentalService service,
                                                ILogger<CreateRentalReturnCommandHandler> logger)
        {
            _service = service;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateRentalReturnCommand request, CancellationToken cancellationToken)
        {
            var rental = await _service.FirstOrDefaultAsync(x => x.Id == request.Id)
                       ?? throw new ArgumentException($"O id: '{request.Id}' informado não existe.");

            if (request.ReturnDate < rental.StartDate)
                throw new ArgumentException($"A  data informada é anterior a data de início da locação.");

            var totalamount = await _service.CalculateReturValue(rental, request.ReturnDate);

            _logger.LogInformation($"Valor total da locação com devolução em {request.ReturnDate}: R${Math.Round(totalamount, 2)}");

            rental.CreateReturn(totalamount, request.ReturnDate);

            await _service.SaveAsync(rental);

            _logger.LogInformation("Devolução criada com sucesso.");

            return true;
        }
    }
}
