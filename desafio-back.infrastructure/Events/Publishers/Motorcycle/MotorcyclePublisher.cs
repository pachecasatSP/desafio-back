using desafio_back.domain.Abstractions.Publishers;
using desafio_back.domain.Events;
using MassTransit;

namespace desafio_back.infrastructure.Events.Publishers.Motorcycle
{
    public class MotorcyclePublisher : IMotorcyclePublisher
    {
        private IPublishEndpoint _publishEndpoint;

        public MotorcyclePublisher(IPublishEndpoint publishEndpoint) => _publishEndpoint = publishEndpoint;

        public async Task PublishCreatedMotorcycleEvent(MotorcycleCreatedEvent @event) =>
            await _publishEndpoint.Publish(@event);

        public async Task PublishNew2024MotorcycleCreatedEvent(New2024CreatedMotorcycleEvent @event) =>
            await _publishEndpoint.Publish(@event);
    }
}
