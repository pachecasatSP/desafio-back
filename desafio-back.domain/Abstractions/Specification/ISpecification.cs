using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Abstractions.Specification
{
    public interface ISpecification<T> where T : EntityBase
    {
        bool IsSatisfiedBy(T entity);
    }
}
