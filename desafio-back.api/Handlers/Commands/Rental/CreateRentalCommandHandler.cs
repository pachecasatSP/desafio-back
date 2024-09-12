using AutoMapper;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Commands;
using desafio_back.domain.Entities.DomainEntities;
using MediatR;

namespace desafio_back.api.Handlers.Commands
{
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Rental>
    {
        private IDeliverymanService? _deliverymanService;
        private IMotorcycleService? _motorcycleService;
        private IRentalPlanService? _rentalPlanService;
        private IMapper _mapper;
        private ILogger _logger;

        public CreateRentalCommandHandler(IDeliverymanService deliverymanService,
                                          IMotorcycleService motorcycleService,
                                          IRentalPlanService rentalPlanService,
                                          IMapper mapper,
                                          ILogger<CreateRentalCommandHandler> logger)
        {
            _deliverymanService = deliverymanService;
            _motorcycleService = motorcycleService;
            _rentalPlanService = rentalPlanService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Rental> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            var deliveryMan = await _deliverymanService!.FirstOrDefaultAsync(x => x.Id == request.EntregadorId)
                             ?? throw new ArgumentException("Não foi possível encontrar o entregador pelo identificador informado.");
            var motorcycle = await _motorcycleService!.FirstOrDefaultAsync(x => x.Id == request.MotoId)
                            ?? throw new ArgumentException("Não foi possível encontrar a moto pelo identificador informado.");
            var plan = await _rentalPlanService!.FirstOrDefaultAsync(x => x.Id == request.Plano.ToString())
                            ?? throw new ArgumentException("Não foi possível encontrar o plano pelo identificador informado.");

            var rental = _mapper.Map<Rental>(request);

            motorcycle.AddRental(rental);
            plan.AddRental(rental);
            deliveryMan.AddRental(rental);

            await _deliverymanService.SaveAsync(deliveryMan);

            _logger.LogInformation($"Rental with id:{rental.Id} was created.");
            return rental;

        }
    }
}
