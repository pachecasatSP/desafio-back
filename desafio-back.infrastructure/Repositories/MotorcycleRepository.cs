using desafio_back.domain.Abstractions.Publishers;
using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Entities.DomainEntities;
using desafio_back.domain.Events;
using desafio_back.infrastructure.Repositories.Context;

namespace desafio_back.infrastructure.Repositories;

public class MotorcycleRepository : RepositoryBase<Motorcycle>, IMotorcycleRepository
{
    private IMotorcyclePublisher _publisher;

    public MotorcycleRepository(RentalManagementContext dbContext,
                                IMotorcyclePublisher publisher)
        : base(dbContext)
    {
        _publisher = publisher;
    }

    public override async Task<Motorcycle> AddAsync(Motorcycle entity)
    {
        var entityMessage = await base.AddAsync(entity);
        await _publisher.PublishCreatedMotorcycleEvent(new MotorcycleCreatedEvent(entityMessage));
        return entityMessage;

    }
}
