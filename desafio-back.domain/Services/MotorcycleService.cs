using desafio_back.api.Services;
using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.DomainEntities;
using System.Linq.Expressions;

namespace desafio_back.domain.Services
{
    public class MotorcycleService : ServiceBase<Motorcycle>, IMotorcycleService
    {
        public MotorcycleService(IMotorcycleRepository repository) => _repository = repository;

        public async Task<bool> PlateDoesNotExists(string placa) =>
         await FirstOrDefaultAsync(x => x.Plate == placa) is null;

        public async Task<bool> IdDoesNotExists(string identificador) =>
            await FirstOrDefaultAsync(x => x.Id == identificador) is null;
        public async Task<bool> IdExists(string identificador) =>
           await FirstOrDefaultAsync(x => x.Id == identificador) != null;

        public override async Task<Motorcycle> FirstOrDefaultAsync(Expression<Func<Motorcycle, bool>> predicate) =>
            await _repository.FirstOrDefaultAsync(predicate);
    }
}
