using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Models.Entities;
using System.Linq.Expressions;

namespace desafio_back.api.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private IMotorcycleRepository _repository;

        public MotorcycleService(IMotorcycleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Motorcycle> FirstOrDefaultAsync(Expression<Func<Motorcycle, bool>> predicate) =>
            await _repository.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Motorcycle>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Motorcycle> QueryAsync(string identificador, string? filter = null) =>
            await _repository.GetAsync(identificador);

        public async Task<Motorcycle> SaveAsync(Motorcycle entity)
        {
            if (entity.InternalId == 0)
                return await _repository.AddAsync(entity);

            return await _repository.UpdateAsync(entity);
        }
        public async Task<bool> DeleteAsync(string identificador)
        {

            var entity = await _repository.FirstOrDefaultAsync(x => x.Identificador == identificador);
            if (entity is null)
                return false;

            await _repository.DeleteAsync(entity.InternalId);
            return true;
        }

        public async Task<bool> PlateDoesNotExists(string placa) =>
         (await FirstOrDefaultAsync(x => x.Placa == placa)) is null;

        public async Task<bool> IdDoesNotExists(string identificador) =>
            (await FirstOrDefaultAsync(x => x.Identificador == identificador)) is null;

    }
}
