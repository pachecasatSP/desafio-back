using desafio_back.domain.Entities.DomainEntities;
using desafio_back.domain.Models.Entities;
using desafio_back.infrastructure.Events;
using Microsoft.EntityFrameworkCore;

namespace desafio_back.infrastructure.Repositories.Context
{
    public class RentalManagementContext : DbContext
    {
        private EventStore _eventStore;

        public RentalManagementContext(DbContextOptions<RentalManagementContext> options,
                                       EventStore eventStore)
            : base(options) {

            _eventStore = eventStore;
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }

        public DbSet<RentalPlan> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryMan>(entity =>
            {
                entity.ToTable("entregador");

                entity.HasKey(e => e.InternalId);
                entity.Property(e => e.Nome).HasColumnName("nome").HasMaxLength(255);
                entity.Property(e => e.Cnpj).HasColumnName("cnpj").HasMaxLength(14);
                entity.Property(e => e.Data_nascimento).HasColumnName("datanascimento").HasColumnType("date");
                entity.Property(e => e.Numero_cnh).HasColumnName("numerocnh").HasMaxLength(20);
                entity.Property(e => e.Tipo_cnh).HasColumnName("tipocnh").HasMaxLength(10);
                entity.Property(e => e.Imagem_cnh).HasColumnName("imagemcnh").HasMaxLength(500);
                entity.Property(e => e.Timestamp).HasColumnName("timestamp").HasDefaultValueSql("now()");


                entity.HasMany(e => e.RentalCollection)
                    .WithOne(r => r.DeliveryMan)
                    .HasForeignKey(r => r.InternalId);
            });

            modelBuilder.Entity<Motorcycle>(entity =>
            {

                entity.ToTable("moto");

                entity.Property(e => e.Ano).HasColumnName("ano");
                entity.Property(e => e.Modelo).HasColumnName("modelo").HasMaxLength(100);
                entity.Property(e => e.Placa).HasColumnName("placa").HasMaxLength(8);
                entity.Property(e => e.Placa).HasColumnType("varchar(8)");
                entity.Property(e => e.Timestamp).HasColumnName("timestamp").HasDefaultValueSql("now()");

                entity.HasIndex(e => e.Placa).IsUnique();
                entity.HasKey(e => e.InternalId);

            });

            modelBuilder.Entity<RentalPlan>(entity =>
            {

                entity.ToTable("plano");

                entity.HasKey(e => e.InternalId);
                entity.Property(e => e.PrazoDias).HasColumnName("prazodias");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Valor).HasColumnName("valor");
                entity.Property(e => e.Timestamp).HasColumnName("timestamp").HasDefaultValueSql("now()");

                entity.HasIndex(e => e.Identificador).IsUnique();
            });

            modelBuilder.Entity<Rental>(entity =>
            {

                entity.ToTable("locacao");

                entity.HasKey(e => e.InternalId);

                entity.Property(e => e.Entregador_id).HasColumnName("entregador_id").HasColumnType("varchar(25)").HasMaxLength(25);
                entity.Property(e => e.Moto_id).HasColumnName("moto_id").HasColumnType("varchar(25)").HasMaxLength(25);
                entity.Property(e => e.Data_inicio).HasColumnName("data_inicio").HasColumnType("timestamp");
                entity.Property(e => e.Data_termino).HasColumnName("data_termino").HasColumnType("timestamp");
                entity.Property(e => e.Data_previsao_termino).HasColumnName("data_previsao_termino").HasColumnType("timestamp");
                entity.Property(e => e.Timestamp).HasColumnName("timestamp").HasDefaultValueSql("now()");

                entity.HasOne(e => e.DeliveryMan)
                    .WithMany()
                    .HasForeignKey(e => e.InternalId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Motorcycle)
                    .WithMany()
                    .HasForeignKey(e => e.InternalId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Plano)
                    .WithMany()
                    .HasForeignKey(e => e.InternalId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
