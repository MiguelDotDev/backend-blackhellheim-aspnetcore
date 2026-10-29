using Blackhellheim.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blackhellheim.Infraestructure.Persistence;

public class BlackhellheimDbContext : DbContext
{
    public BlackhellheimDbContext(DbContextOptions options) : base(options)
    {
    }

    protected BlackhellheimDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlackhellheimDbContext).Assembly);
    }
    public DbSet<Producto> Productos { get; set; }
}
