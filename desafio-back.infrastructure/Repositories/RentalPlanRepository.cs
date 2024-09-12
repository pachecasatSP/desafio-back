using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Entities.DomainEntities;
using desafio_back.infrastructure.Repositories.Context;

namespace desafio_back.infrastructure.Repositories;

public class RentalPlanRepository : RepositoryBase<RentalPlan>, IRentalPlanRepository
{
    public RentalPlanRepository(RentalManagementContext context)
        : base(context) { }
}
