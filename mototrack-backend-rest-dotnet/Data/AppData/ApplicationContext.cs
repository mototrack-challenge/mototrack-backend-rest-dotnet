using Microsoft.EntityFrameworkCore;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Data.AppData;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<MotoEntity> Moto { get; set; }
}
