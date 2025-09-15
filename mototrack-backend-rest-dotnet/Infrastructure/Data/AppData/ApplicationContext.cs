using Microsoft.EntityFrameworkCore;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Infrastructure.Data.AppData;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MotoEntity>(entity =>
        {
            //entity.HasKey(e => e.Id);

            //entity.Property(m => m.Id)
            //    .HasColumnName("ID_MOTO")
            //    .ValueGeneratedOnAdd()
            //    .HasDefaultValueSql("MOTO_SEQ.NEXTVAL");

            //entity.HasIndex(e => e.Placa).IsUnique();
            //entity.HasIndex(e => e.Chassi).IsUnique();

            entity.Property(e => e.Modelo).HasConversion<string>();
            entity.Property(e => e.Status).HasConversion<string>();
        });

        modelBuilder.Entity<ServicoEntity>(entity =>
        {
            entity.Property(s => s.Status).HasConversion<string>();
            entity.HasIndex(s => s.MotoId);
            entity.HasIndex(s => s.ColaboradorId);
        });
    }

    public DbSet<MotoEntity> Moto { get; set; }
    public DbSet<ColaboradorEntity> Colaborador { get; set; }

    public DbSet<ServicoEntity> Servico { get; set; }
}
