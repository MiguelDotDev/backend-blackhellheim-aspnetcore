using Blackhellheim.Domain.Entities;

namespace Blackhellheim.Application.Contracts;

public interface IRepositoriyProducts
{
    Task Agregar(Producto producto);
}
