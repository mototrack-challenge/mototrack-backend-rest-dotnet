using Microsoft.EntityFrameworkCore;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Data.AppData;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MotoEntity>()
            .HasIndex(m => m.Placa)
            .IsUnique();

        modelBuilder.Entity<MotoEntity>()
            .HasIndex(m => m.Chassi)
            .IsUnique();
    }

    public DbSet<MotoEntity> Moto { get; set; }
}
