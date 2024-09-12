using desafio_back.domain.Abstractions.Events;
using desafio_back.domain.Entities.DomainEntities;

namespace desafio_back.domain.Events
{
    public class MotorcycleCreatedEvent : EventBase<Motorcycle>
    {
        public MotorcycleCreatedEvent(Motorcycle entity)
            : base(entity) { }

        public override string ToString()
        {
            return $"Moto{base.ToString()}foi criada.";
        }
    }
}
