using desafio_back.domain.Abstractions.Publishers;
using desafio_back.domain.Events;
using desafio_back.domain.Rules;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace desafio_back.infrastructure.Events.Consumers
{
    public class CreatedMotorcycleConsumer : IConsumer<MotorcycleCreatedEvent>
    {
        private IMotorcyclePublisher _publisher;
        private ILogger<CreatedMotorcycleConsumer> _logger;
        private readonly EventStore _eventStore;
        private readonly Is2024MotorcycleRule _rule;

        public CreatedMotorcycleConsumer(IMotorcyclePublisher publisher,
                                         ILogger<CreatedMotorcycleConsumer> logger,
                                         EventStore eventStore,
                                         Is2024MotorcycleRule rule)
        {
            _publisher = publisher;
            _logger = logger;
            _eventStore = eventStore;
            _rule = rule;
        }

        public async Task Consume(ConsumeContext<MotorcycleCreatedEvent> context)
        {
            _logger.LogInformation($"Received message with id: {context.MessageId}");

            var message = context.Message;

            _logger.LogInformation(message.Entity.ToString());

            await _eventStore.SaveAudit(message);

            Send2024EventIfApply(message);

            _logger.LogInformation($"Processed message with id: {context.MessageId}");
        }
        private void Send2024EventIfApply(MotorcycleCreatedEvent message)
        {
            if (_rule.Apply(message.Entity))
                _publisher.PublishNew2024MotorcycleCreatedEvent(new New2024CreatedMotorcycleEvent(message.Entity));
        }
    }
}
