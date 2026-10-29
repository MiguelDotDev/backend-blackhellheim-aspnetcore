using Blackhellheim.Application.Contracts;
using Blackhellheim.Domain.Entities;

namespace Blackhellheim.Infraestructure.Persistence.Repository;

public class RepositoryProducts(BlackhellheimDbContext context) : IRepositoriyProducts
{
    public async Task Agregar(Producto producto)
    {
        context.Add(producto);
        await context.SaveChangesAsync();
    }
}
