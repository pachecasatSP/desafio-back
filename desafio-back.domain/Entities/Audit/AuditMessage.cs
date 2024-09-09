namespace desafio_back.domain.Models.Audit
{
    public class AuditMessage
    {
        public int InternalId { get; set; }
        public DateTime Timestamp { get; set; }
        public string RawMessage { get; set; } = string.Empty;
    }
}
