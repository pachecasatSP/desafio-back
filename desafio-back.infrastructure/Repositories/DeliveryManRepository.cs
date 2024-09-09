using desafio_back.domain.Models.Entities;
using desafio_back.infrastructure.Repositories.Base;
using desafio_back.infrastructure.Repositories.Context;

namespace desafio_back.infrastructure.Repositories
{
    internal class DeliveryManRepository : RepositoryBase<DeliveryMan>
    {
        public DeliveryManRepository(RentalManagementContext context) : 
            base(context)
        {
        }
    }
}
