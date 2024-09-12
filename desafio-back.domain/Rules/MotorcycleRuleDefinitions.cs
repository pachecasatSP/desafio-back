using desafio_back.domain.Entities.DomainEntities;
using desafio_back.domain.Specifications;

namespace desafio_back.domain.Rules
{
    public class Is2024MotorcycleRule(Motorcycle2024Specification specification) :
        SpecificationRuleBase<Motorcycle, Motorcycle2024Specification>(specification)
    { }
}
