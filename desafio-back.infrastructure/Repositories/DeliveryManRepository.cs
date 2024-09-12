using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Entities.DomainEntities;
using desafio_back.infrastructure.Repositories.Context;

namespace desafio_back.infrastructure.Repositories;

public class DeliveryManRepository : RepositoryBase<DeliveryMan>, IDeliveryManRepository
{
    public DeliveryManRepository(RentalManagementContext context) :
        base(context)
    { }
}
