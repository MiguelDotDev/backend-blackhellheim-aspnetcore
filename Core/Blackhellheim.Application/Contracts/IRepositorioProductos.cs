using Blackhellheim.Domain.Entities;

namespace Blackhellheim.Application.Contracts;

public interface IRepositorioProductos
{
    Task Agregar(Producto producto);
}
