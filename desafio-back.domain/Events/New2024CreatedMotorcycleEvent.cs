using desafio_back.domain.Abstractions.Events;
using desafio_back.domain.Entities.DomainEntities;

namespace desafio_back.domain.Events
{
    public class New2024CreatedMotorcycleEvent : EventBase<Motorcycle>
    {
        public New2024CreatedMotorcycleEvent(Motorcycle entity) :
            base(entity)
        { }

        public override string ToString()
        {
            return $"Nova moto 2024 {Entity.ToString()} foi criada.";
        }
    }
}
