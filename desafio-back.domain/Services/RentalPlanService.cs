using desafio_back.api.Services;
using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.DomainEntities;
using System.Linq.Expressions;

namespace desafio_back.domain.Services;

public class RentalPlanService : ServiceBase<RentalPlan>, IRentalPlanService
{
    public RentalPlanService(IRentalPlanRepository repository) => _repository = repository;

    public override async Task<RentalPlan> FirstOrDefaultAsync(Expression<Func<RentalPlan, bool>> predicate) =>
        await _repository!.FirstOrDefaultAsync(predicate);

    public async Task<bool> RentalPlanExists(int planId) =>
        await FirstOrDefaultAsync(x => x.Id == planId.ToString()) != null;

    public async Task<int> RentalPlanTermInDays(int planId) =>
        (await FirstOrDefaultAsync(x => x.Id == planId.ToString()))?.TermInDays ?? 0;
}
