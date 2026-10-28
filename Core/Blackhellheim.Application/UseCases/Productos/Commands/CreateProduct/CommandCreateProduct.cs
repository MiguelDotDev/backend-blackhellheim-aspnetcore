namespace Blackhellheim.Application.UseCases.Productos.Commands.CreateProduct;

public record CommandCreateProduct(
    string titulo, string slug, string descripcion, int categoria_id
);