using desafio_back.domain.Abstractions.Publishers;
using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Events;
using desafio_back.domain.Models.Entities;
using desafio_back.infrastructure.Repositories.Base;
using desafio_back.infrastructure.Repositories.Context;

namespace desafio_back.web.api.Repositories
{
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
}
