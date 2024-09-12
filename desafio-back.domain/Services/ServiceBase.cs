using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Models.Base;
using System.Linq.Expressions;

namespace desafio_back.api.Services
{
    public abstract class ServiceBase<TEntity> : IService<TEntity> where TEntity : EntityBase
    {
        protected IRepository<TEntity>? _repository;

        public async Task<bool> DeleteAsync(string identificador)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == identificador);
            if (entity is null)
                return false;

            await _repository.DeleteAsync(entity.InternalId);
            return true;
        }

        public abstract Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public Task<TEntity> QueryAsync(string identificador, string filter)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            if (entity.InternalId == 0)
                return await _repository.AddAsync(entity);

            return await _repository.UpdateAsync(entity);
        }

    }
}