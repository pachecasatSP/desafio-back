using desafio_back.domain.Abstractions.Events;
using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Models.Audit;
using Newtonsoft.Json;

namespace desafio_back.infrastructure.Events
{
    public class EventStore
    {
        private IAuditRepository _repository;

        public EventStore(IAuditRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveAudit(IEvent message) =>
            await _repository.Create(new AuditMessage()
            {
                RawMessage = JsonConvert.SerializeObject(message)
            });

        public async Task GetAllMessages() =>
            await _repository.GetAll();

        //public IEnumerable<IEvent> EventCollection { get; set; }
    }
}
