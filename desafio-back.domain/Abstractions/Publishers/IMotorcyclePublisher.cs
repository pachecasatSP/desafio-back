using desafio_back.domain.Events;

namespace desafio_back.domain.Abstractions.Publishers
{
    public interface IMotorcyclePublisher
    {
        Task PublishCreatedMotorcycleEvent(MotorcycleCreatedEvent @event);

        Task PublishNew2024MotorcycleCreatedEvent(New2024CreatedMotorcycleEvent @event);

    }
}
