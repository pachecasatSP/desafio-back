using desafio_back.domain.Models.Base;
using System.Linq.Expressions;

namespace desafio_back.domain.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase, new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(string identificador);
        Task<bool> DeleteAsync(int internalId);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
