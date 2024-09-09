namespace desafio_back.domain.Models.Base
{
    public class EntityBase
    {
        public int InternalId { get; set; }

        public string Identificador { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    }
}
