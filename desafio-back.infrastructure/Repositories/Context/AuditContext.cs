using desafio_back.domain.Models.Audit;
using Microsoft.EntityFrameworkCore;

namespace desafio_back.infrastructure.Repositories.Context;
public class AuditContext : DbContext
{
    public AuditContext(DbContextOptions<AuditContext> options)
        : base(options)
    { }

    public DbSet<AuditMessage> AuditMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditMessage>(entity =>
        {
            entity.ToTable("auditmessage");

            entity.HasKey(e => e.InternalId);
            entity.Property(e => e.InternalId).UseIdentityColumn();
            entity.Property(e => e.RawMessage).HasColumnType("jsonb");
            entity.Property(e => e.Timestamp).HasDefaultValueSql("now()");
        });
        base.OnModelCreating(modelBuilder);
    }
}
