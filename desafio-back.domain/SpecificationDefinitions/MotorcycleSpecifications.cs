using desafio_back.domain.Abstractions.Specification;
using desafio_back.domain.Models.Entities;

namespace desafio_back.domain.Specifications
{
    public class Motorcycle2024Specification : ISpecification<Motorcycle>
    {
        private const int YEAR2024 = 2024;

        public bool IsSatisfiedBy(Motorcycle entity) => entity.Ano == YEAR2024;
    }
}
