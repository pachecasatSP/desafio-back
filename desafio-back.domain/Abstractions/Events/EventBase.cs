using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Abstractions.Events
{
    public abstract class EventBase<TEntity> : IEvent where TEntity : EntityBase
    {
        protected EventBase(TEntity entity) => Entity = entity;

        public TEntity Entity { get; set; }

    }
}
