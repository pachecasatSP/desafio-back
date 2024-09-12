using desafio_back.domain.Abstractions.Rule;
using desafio_back.domain.Abstractions.Specification;
using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Rules
{
    public abstract class SpecificationRuleBase<TEntity, TSpecification> : ISpecificationRule<TEntity, TSpecification>
        where TEntity : EntityBase
        where TSpecification : ISpecification<TEntity>
    {
        private TSpecification _specification;

        protected SpecificationRuleBase(TSpecification specification) => _specification = specification;

        public bool Apply(TEntity entity) =>
            _specification.IsSatisfiedBy(entity);

        public IEnumerable<TEntity> Apply(IEnumerable<TEntity> entities) =>
            entities.Where(_specification.IsSatisfiedBy);
    }
}
