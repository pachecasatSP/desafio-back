using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Models.Audit;
using desafio_back.infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace desafio_back.infrastructure.Repositories.Audit
{
    public class AuditRepository : IAuditRepository
    {
        private AuditContext _context;

        public AuditRepository(AuditContext context) => _context = context;

        public async Task Create(AuditMessage message)
        {
            using var ctx = _context;
            ctx.AuditMessages.Add(message);
            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuditMessage>> GetAll()
        {
            using var ctx = _context;
            return await ctx.AuditMessages.ToListAsync();
        }

    }
}
