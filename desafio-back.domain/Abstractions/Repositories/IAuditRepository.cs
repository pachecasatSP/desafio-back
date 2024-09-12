using desafio_back.domain.Models.Audit;

namespace desafio_back.domain.Abstractions.Repositories
{
    public interface IAuditRepository
    {
        Task Create(AuditMessage message);
        Task<IEnumerable<AuditMessage>> GetAll();
    }
}
