using desafio_back.domain.Entities.DomainEntities;
using desafio_back.infrastructure.Events;
using Microsoft.EntityFrameworkCore;

namespace desafio_back.infrastructure.Repositories.Context;

public class RentalManagementContext : DbContext
{
    private EventStore _eventStore;

    public RentalManagementContext(DbContextOptions<RentalManagementContext> options,
                                   EventStore eventStore)
        : base(options)
    {

        _eventStore = eventStore;
    }

    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<Rental> Rental { get; set; }
    public DbSet<DeliveryMan> DeliveryMen { get; set; }
    public DbSet<RentalPlan> Plans { get; set; }
    public DbSet<RentalReturn> Returns { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeliveryMan>(entity =>
        {
            entity.ToTable("entregador");

            entity.HasKey(e => e.InternalId);
            entity.Property(e => e.Id).HasColumnName("identificador");
            entity.Property(e => e.Name).HasColumnName("nome").HasMaxLength(255);
            entity.Property(e => e.Cnpj).HasColumnName("cnpj").HasMaxLength(14);
            entity.Property(e => e.BirthDate).HasColumnName("datanascimento").HasColumnType("date");
            entity.Property(e => e.CNHNumber).HasColumnName("numerocnh").HasMaxLength(20);
            entity.Property(e => e.CNHType).HasColumnName("tipocnh").HasMaxLength(10);
            entity.Property(e => e.CNHImage).HasColumnName("imagemcnh").HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("now()");

            entity.HasIndex(e => e.Cnpj).IsUnique();
            entity.HasIndex(e => e.CNHNumber).IsUnique();

        });

        modelBuilder.Entity<Motorcycle>(entity =>
        {

            entity.ToTable("moto");

            entity.Property(e => e.Id).HasColumnName("identificador");
            entity.Property(e => e.Year).HasColumnName("ano");
            entity.Property(e => e.Model).HasColumnName("modelo").HasMaxLength(100);
            entity.Property(e => e.Plate).HasColumnName("placa").HasMaxLength(8);
            entity.Property(e => e.Plate).HasColumnType("varchar(8)");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("now()");

            entity.HasIndex(e => e.Plate).IsUnique();
            entity.HasKey(e => e.InternalId);

        });

        modelBuilder.Entity<RentalPlan>(entity =>
        {

            entity.ToTable("plano");

            entity.HasKey(e => e.InternalId);
            entity.Property(e => e.Id).HasColumnName("identificador");
            entity.Property(e => e.TermInDays).HasColumnName("prazoemdias");
            entity.Property(e => e.Name).HasColumnName("nome");
            entity.Property(e => e.Value).HasColumnName("valor");
            entity.Property(e => e.EarlyPenalty).HasColumnName("multa_antecipacao");
            entity.Property(e => e.AdditionalDayValue).HasColumnName("valordiaadicional");

            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("now()");

            entity.HasIndex(e => e.Id).IsUnique();
        });

        modelBuilder.Entity<Rental>(entity =>
        {

            entity.ToTable("locacao");

            entity.HasKey(e => e.InternalId);
            entity.Property(e => e.Id).HasColumnName("identificador");
            entity.Property(e => e.DeliveryManId).HasColumnName("entregador_id");
            entity.Property(e => e.MotorcycleId).HasColumnName("moto_id");
            entity.Property(e => e.StartDate).HasColumnName("data_inicio").HasColumnType("date");
            entity.Property(e => e.EndDate).HasColumnName("data_termino").HasColumnType("date");
            entity.Property(e => e.ForecastEndDate).HasColumnName("data_previsao_termino").HasColumnType("date");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("now()");

            entity.HasOne(e => e.Plan)
                    .WithMany(e => e.RentalCollection)
                    .HasPrincipalKey(e => e.InternalId)
                    .HasForeignKey(e => e.PlanId);
            entity.HasOne(e => e.Motorcycle)
                    .WithMany(e => e.RentalCollection)
                    .HasPrincipalKey(e => e.InternalId)
                    .HasForeignKey(e => e.MotorcycleId);
            entity.HasOne(e => e.DeliveryMan)
                    .WithMany(e => e.RentalCollection)
                    .HasPrincipalKey(e => e.InternalId)
                    .HasForeignKey(e => e.DeliveryManId);

        });

        modelBuilder.Entity<RentalReturn>(entity =>
        {
            entity.ToTable("devolucao");

            entity.HasKey(e => e.InternalId);
            entity.Property(e => e.Id).HasColumnName("identificador");
            entity.Property(e => e.RentalId).HasColumnName("rental_id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Value).HasColumnType("decimal");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("now()");

            entity.HasOne(e => e.Rental).WithOne(e => e.RentalReturn);

        });

        base.OnModelCreating(modelBuilder);
    }

}
