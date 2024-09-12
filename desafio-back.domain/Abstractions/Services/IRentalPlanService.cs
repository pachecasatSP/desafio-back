using desafio_back.domain.Entities.DomainEntities;

namespace desafio_back.domain.Abstractions.Services
{
    public interface IRentalPlanService : IService<RentalPlan>
    {
        Task<bool> RentalPlanExists(int planId);
        Task<int> RentalPlanTermInDays(int planId);
    }
}
