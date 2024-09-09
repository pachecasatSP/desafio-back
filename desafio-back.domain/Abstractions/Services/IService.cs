using desafio_back.domain.Models.Base;
using System.Linq.Expressions;

namespace desafio_back.domain.Abstractions.Services
{
    public interface IService<TEntity> where TEntity : EntityBase, new()
    {
        Task<TEntity> QueryAsync(string identificador, string filter);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> SaveAsync(TEntity entity);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteAsync(string identificador);   
    }
}
