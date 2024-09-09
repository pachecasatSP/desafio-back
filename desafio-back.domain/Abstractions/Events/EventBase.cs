using desafio_back.domain.Models.Base;
using System.Text;

namespace desafio_back.domain.Abstractions.Events
{
    public abstract class EventBase<TEntity>: IEvent where TEntity: EntityBase
    {
        protected EventBase(TEntity entity) => Entity = entity;

        public TEntity Entity { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            foreach (var prop in typeof(TEntity).GetProperties())
                sb.Append($" {prop.Name}: {prop.GetValue(Entity)} ");
            
            return sb.ToString();
        }
    }
}
