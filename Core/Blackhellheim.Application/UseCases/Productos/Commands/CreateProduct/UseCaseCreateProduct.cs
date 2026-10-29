using Blackhellheim.Application.Contracts;
using Blackhellheim.Domain.Entities;

namespace Blackhellheim.Application.UseCases.Productos.Commands.CreateProduct;

public class UseCaseCreateProduct(IRepositoriyProducts repositorioProductos)
{
    //Validaciones que tienen que ver con la BD

    public async Task<Guid> Handle(CommandCreateProduct comando)
    {
        var producto = Producto.Crear(
            comando.titulo,
            comando.slug,
            comando.descripcion,
            comando.categoria_id);
        
        await repositorioProductos.Agregar(producto);
        return producto.Id;
    }
}