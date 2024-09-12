using System.Text;

namespace desafio_back.domain.Models.Base
{
    public class EntityBase
    {
        public int InternalId { get; set; }

        public virtual string Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var prop in GetType().GetProperties())
                sb.Append($" {prop.Name}: {prop.GetValue(this)} ");

            return sb.ToString();
        }
    }
}
