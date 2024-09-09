using desafio_back.domain.Abstractions.Specification;
using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Abstractions.Rule
{
    public interface ISpecificationRule<TEntity, TSpecification> 
        where TEntity : EntityBase 
        where TSpecification : ISpecification<TEntity>
    {
        bool Apply(TEntity entity);
        IEnumerable<TEntity> Apply(IEnumerable<TEntity> entities);
    }
}
