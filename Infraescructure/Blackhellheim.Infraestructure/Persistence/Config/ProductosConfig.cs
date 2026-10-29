using Blackhellheim.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blackhellheim.Infraestructure.Persistence.Config;

public class ProductosConfig: IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.Property(prop => prop.Titulo)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(prop => prop.Titulo).IsUnique();

        builder.Property(prop => prop.Descripcion)
            .HasMaxLength(2000);
    }
}
